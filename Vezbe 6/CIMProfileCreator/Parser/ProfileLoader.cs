using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelventDMS.Integration.CIM.Model;
using TelventDMS.Integration.CIM.Parser;
using ModelConverter;
using System.Threading;
using TelventDMS.Integration.CIM.Manager;
using TelventDMS.Integration.CIM.Parser.Handler;
using System.Configuration;
using System.IO;
using CIMProfileCreator.Utilities;
using CIMProfileCreator.Model;
using CIMProfileCreator.Model.Tools;

namespace TelventDMS.Integration.CIM.Parser
{
    public class ProfileLoader
    {
		/// <summary> When true, all predefined Data types will be removed from profile and properties will have simple type values (e.g. instead of data type 'Voltage', 'float' will be used for property type). </summary>
		public static bool RemoveDataTypes = true;

        #region FIELDS

        /// <summary>
        /// profile with the information
        /// </summary>
        private Profile profile;

        /// <summary>
        /// List that contains <typeparamref name="ProfileElement"/> elements that are referenced in
        /// <c>profile</c> classes, but not defined. This list represents elements that will be
        /// completed with the information aquired from the EAP model of the standard.
        /// </summary>
        private List<Class> predefined = new List<Class>();

        #endregion


        /// <summary>
        /// Delegate for messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public delegate void MessageEventHandler(object sender, string message);

        /// <summary>
        /// Delegate for done parsing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="model"></param>
        public delegate void DoneParsingEventHandler(object sender, Profile profile);


        /// <summary>
        /// Parsing finished event
        /// </summary>
        public event DoneParsingEventHandler DoneParsing;

        /// <summary>
        /// Event for messages
        /// </summary>
        public event MessageEventHandler Message;


        protected virtual void OnMessage(string message)
        {
            if(Message != null)
                Message(this, message);
        }

        protected virtual void OnDoneParsing(Profile profile)
        {
            if(profile != null)
            {
                DoneParsing(this, profile);
            }
        }

        /// <summary>
        /// Parse RDF file from <c>path</c> and create profile
        /// </summary>
        /// <param name="profile">Profile profile the data will be stored in</param>
        public Profile LoadProfileDocument(Stream stream, string path, bool createCore)
        {
            try
            {
                this.profile = new Profile();
                profile.SourcePath = path;
                StringBuilder message = new StringBuilder();
                message.Append("\r\n\t------------------Parsing profile------------------");
                message.Append("\r\nParsing file:" + profile.SourcePath);
                OnMessage(message.ToString());
                if((profile != null) && (!string.IsNullOrEmpty(profile.SourcePath)))
                {
                    bool success;
                    TimeSpan durationOfParsing = new TimeSpan(0);
					RDFSXMLReaderHandler handler = new RDFSXMLReaderHandler();

					handler = (RDFSXMLReaderHandler)XMLParser.DoParse(handler, stream, profile.SourcePath, out success, out durationOfParsing);

                    StringBuilder msg = new StringBuilder("\r\nCIM profile loaded\r\n      Duration of CIM profile loading: " + durationOfParsing);

                    if(success)
                    {
                        profile = handler.Profile;
                        msg.Append("\r\n TOTAL:\r\n\tPackages:" + profile.PackageCount + "\r\n\tClasses:" + profile.ClassCount);
                    }
                    else
                    {
                        msg.Append("\r\n      loading CIM profile was unsuccessful");
                    }
                    OnMessage(msg.ToString());
                }
                else
                {
                    OnMessage("Parsing impossible - no profile or incorrect path");
                    return null;
                }
                OnMessage("\r\n\t--------------Done parsing profile--------------");

                PredefinedClasses pf = new PredefinedClasses();

                if (profile.FindProfileElementByUri("#Package_Core") == null && createCore)
                {
                    pf.CreatePackage(profile, "Package_Core");
                }

                if (profile.FindProfileElementByUri("#UnitSymbol") == null)
                {
                    pf.CreateEnumeration(profile, "UnitSymbol");
                }

                if (profile.FindProfileElementByUri("#UnitMultiplier") == null)
                {
                    pf.CreateEnumeration(profile, "UnitMultiplier");
                }
                
                extractEmptyClasses();
                
                if(predefined.Count > 0)
                {
                    while(predefined.Count > 0)
                    {
                        //find the class in model
                        foreach(Class e in predefined)
                        {
                            pf.updateClassData(e,profile);
                        }
                        
                        addPredefined();
                        
                        extractEmptyClasses();
                    }
                }

				if (RemoveDataTypes)
				{
					//// replace predefined data types with simple types
					ReplaceDataTypesWithSimpleTypes(pf);
					ExcludeDataTypesFromProfile(pf);
				}

                return profile;
            }
            catch(ThreadAbortException)
            {
                return null;
            }
        }

        #region Support Methods

        
        private void addPredefined()
        {
            foreach(Class el in predefined)
            {
                el.BelongsToCategory = "#Package_Core";
                el.BelongsToCategoryAsObject = profile.FindProfileElementByName(StringManipulationManager.ExtractAllAfterSeparator(el.BelongsToCategory,StringManipulationManager.SeparatorSharp));
                ((ClassCategory)profile.FindProfileElementByName(StringManipulationManager.ExtractAllAfterSeparator(el.BelongsToCategory,StringManipulationManager.SeparatorSharp))).AddToMembersOfClassCategory(el);
            }
            predefined.Clear();
        }

        /// <summary>
        /// Searches through the profile, determining which elements are not complete and adds them to
        /// <c>predefined</c> list.
        /// </summary>
        private void extractEmptyClasses()
        {
            List<Class> elList = new List<Class>();
            elList = profile.GetAllProfileElementsOfType(ProfileElementTypes.Class).Cast<Class>().ToList();
            if(elList != null)
            {
                if(elList.Count > 0)
                {
                    foreach(Class e in elList)
                    {
                        if(string.IsNullOrEmpty(e.BelongsToCategory))
                            predefined.Add(e);
                    }
                }
            }
            OnMessage("\r\nPredefined classes count:" + predefined.Count);
        }
        
        #endregion

        #region URI checks
        /*
        /// <summary>
        /// Method checks if URI is embeded in prefix (base) in xml, and if it is, adds it to places that need it
        /// for easier use later.
        /// </summary>
        /// <param name="profile">Profile profile that is being checked</param>
        public void addMissingURIParts(Profile profile)
        {

            List<ProfileElement> list = new List<ProfileElement>();
            profile.ProfileMap.TryGetValue(ProfileElementTypes.ClassCategory, out list);
            //PACKAGES
            if(list != null)
            {
                //IN EACH PACKAGE
                foreach(ProfileElement package in list)
                {


                    //check URI
                    if(package.URI.StartsWith("#"))
                    {
                        package.URI = profile.BaseNS + package.URI;
                    }

                    List<ProfileElement> classes = package.MembersOfClassCategory;
                    if(classes != null)
                    {
                        foreach(ProfileElement elem in classes)
                        {
                            if(elem.TypeAsEnumValue == ProfileElementTypes.Class)
                            {
                                if(elem.URI.StartsWith("#"))
                                {
                                    elem.URI = profile.BaseNS + elem.URI;
                                }
                                checkPropertiesURI(elem, profile);
                                checkEnumerationURI(elem, profile);
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Checks and adds missing URI parts to enumeration members
        /// </summary>
        /// <param name="elem">ProfileElement enumeration that is being checked</param>
        /// <param name="profile">Profile profile that is being checked</param>
        private void checkEnumerationURI(ProfileElement elem, Profile profile)
        {
            if(elem.MyEnumerationMembers != null)
            {

                foreach(ProfileElement enumMember in elem.MyEnumerationMembers)
                {
                    if(enumMember.URI.StartsWith("#"))
                    {
                        enumMember.URI = profile.BaseNS + enumMember.URI;
                    }
                }
            }
        }

        /// <summary>
        /// Checks and adds missing URI parts to properties
        /// </summary>
        /// <param name="elem">ProfileElement class whose properties are being checked</param>
        /// <param name="profile">Profile profile that is being checked</param>
        private void checkPropertiesURI(ProfileElement elem, Profile profile)
        {
            if(elem.MyProperties != null)
            {
                foreach(ProfileElement property in elem.MyProperties)
                {
                    if(property.URI.StartsWith("#"))
                    {
                        property.URI = profile.BaseNS + property.URI;
                    }
                }
            }
        }
        */
        #endregion

		#region Adjustments to simplify profile
		private void ReplaceDataTypesWithSimpleTypes(PredefinedClasses cimPredefined)
		{
			if ((cimPredefined != null) && (profile != null) && (profile.PropertyCount > 0))
			{
				foreach (Property property in profile.ProfileMap[ProfileElementTypes.Property])
				{
					string dataTypeName = StringManipulationManager.ExtractAllAfterSeparator(property.DataType, StringManipulationManager.SeparatorSharp);
					if (cimPredefined.PedifinedClassesList.Contains(dataTypeName))
					{
						//// read the simple type from "value" attribute
						Class dataTypeClass = profile.FindProfileElementByName(dataTypeName) as Class;
						foreach (Property p in dataTypeClass.MyProperties)
						{
							if (string.Compare(p.Name, "value") == 0)
							{
								property.DataType = p.DataType;
							}
						}
					}
				}
			}
		}

		private void ExcludeDataTypesFromProfile(PredefinedClasses cimPredefined)
		{
			if ((cimPredefined != null) && (profile != null) && (profile.ClassCount > 0))
			{
				ClassCategory packageCorePE = profile.FindProfileElementByUri("#Package_Core") as ClassCategory;
				if (packageCorePE != null)
				{
					foreach (string dataTypeName in cimPredefined.PedifinedClassesList)
					{
						ProfileElement dataTypePE = profile.ProfileMap[ProfileElementTypes.Class].Find(x => string.Compare(x.Name, dataTypeName) == 0);
						if (dataTypePE != null)
						{
							//// remove dataTypePE from package Core
							packageCorePE.MembersOfClassCategory.Remove(dataTypePE);
							//// remove dataTypePE from profile
							profile.ProfileMap[ProfileElementTypes.Class].Remove(dataTypePE);
						}
					}

					//// remove enums UnitSymbol and UnitMultiplier
					ProfileElement unitSymbolPE = profile.FindProfileElementByUri("#UnitSymbol");
					ProfileElement unitMultiplierlPE = profile.FindProfileElementByUri("#UnitMultiplier");
					//// remove from package Core
					packageCorePE.MembersOfClassCategory.Remove(unitSymbolPE);
					packageCorePE.MembersOfClassCategory.Remove(unitMultiplierlPE);
					//// remove from profile
					profile.ProfileMap[ProfileElementTypes.Class].Remove(unitSymbolPE);
					profile.ProfileMap[ProfileElementTypes.Class].Remove(unitMultiplierlPE);
				}
			}
		}
		#endregion
	}
}
