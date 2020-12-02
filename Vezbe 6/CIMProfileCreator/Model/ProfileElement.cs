using System;
using System.Collections.Generic;
using System.ComponentModel;
using TelventDMS.Integration.CIM.Manager;
using TelventDMS.Integration.CIM.Model.Tools;

namespace TelventDMS.Integration.CIM.Model
{
    /// <summary>
    /// Possible types of profile elements
    /// </summary>
    public enum ProfileElementTypes
    {
        Unknown = 0, ClassCategory, Class, Property, EnumerationElement, Stereotype
    };

    /// <summary>
    /// ProfileElement class represents one element founded during processing of profile's source file.
    /// <para>See also: <seealso cref="T:Profile"/></para>
    /// <para>@author: Stanislava Selena</para>
    /// </summary>
    public abstract class ProfileElement
    {
        public const string Separator = StringManipulationManager.SeparatorSharp;

        /// <summary> string with value "classcategory" </summary>
        public const string TypeClassCategoryString = "classcategory";
        /// <summary> string with value "class" </summary>
        public const string TypeClassString = "class";
        /// <summary> string with value "property" </summary>
        public const string TypePropertyString = "property";
        /// <summary> string with value "stereotype" </summary>
        public const string TypeStereotypeString = "stereotype";

        /// <summary> "integer" </summary>
        protected const string SimpleDataTypeInteger = "integer";
        /// <summary> "int" </summary>
        protected const string SimpleDataTypeInt = "int";
        /// <summary> "float"  </summary>
        protected const string SimpleDataTypeFloat = "float";
        /// <summary> "string" </summary>
        protected const string SimpleDataTypeString = "string";
        /// <summary> "dateTime" </summary>
        protected const string SimpleDataTypeDateTime = "datetime";
        /// <summary> "boolean" </summary>
        protected const string SimpleDataTypeBoolean = "boolean";
        /// <summary> "bool" </summary>
        protected const string SimpleDataTypeBool = "bool";
        

        protected string uri;
        protected string type;
        //// creted from shema
        
        protected string label;
        protected string comment;

        protected string multiplicityAsString = "M:0..1";

        public ProfileElement()
        {
        }

        public ProfileElement(string uri)
        {
            this.uri = uri;
        }


        /// <summary>
        /// Gets and sets the full URI of profile element.
        /// </summary>
        public string URI {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }

        /// <summary>
        /// Gets and sets the multiplicityAsString of profile element.
        /// </summary>
        public string MultiplicityAsString
        {
            get
            {
                return multiplicityAsString;
            }
            set
            {
                multiplicityAsString = value;
            }
        }

        /// <summary>
        /// Gets the part of URI after the '#' simbol
        /// </summary>
        public string UniqueName
        {
            get
            {
                string uniqueName = StringManipulationManager.ExtractShortestName(uri, Separator);                
                return uniqueName;
            }            
        }

        /// <summary>
        /// Gets the most simple fullName ( URI.sustring('#').substring('.') )
        /// </summary>
        public string Name
        {
            get
            {
                string name = StringManipulationManager.ExtractShortestName(uri, Separator);
                name = StringManipulationManager.ExtractShortestName(name, StringManipulationManager.SeparatorDot);
                return name;
            }
        }

        /// <summary>
        /// Gets and sets the type of given profile element in string format.
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Gets and sets the label of profile element.
        /// </summary>
        public string Label 
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }

        /// <summary>
        /// gets and sets the comment atached to the profile element.
        /// </summary>
        public string Comment 
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }

        public override bool Equals(object obj)
        {
            bool eq = false;
            if (obj != null)
            {
                if (obj.GetType().Equals(this.GetType()))
                {
                    ProfileElement pelObj = (ProfileElement)obj;
                    if ((pelObj.URI != null) && (this.URI != null))
                    {
                        eq = this.URI.Equals(pelObj.URI);
                    }
                }
            }       
            return eq;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }  
    }
}
