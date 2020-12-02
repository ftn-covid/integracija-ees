using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelventDMS.Integration.CIM.Parser;
using TelventDMS.Integration.CIM.Model;
using System.IO;
using System.Windows.Forms;
using TelventDMS.Integration.CIM.Utilities;

namespace CIMProfileCreator.Utilities
{
    public class ProfileCreator
    {
        private StringBuilder sb;

        public StringBuilder CreateProfile(Stream fs, string namespc, string fileName, string productName, bool createCore,  string AssemblyVersion)
        {
            sb = new StringBuilder(); 
            ////LOAD RDFS AND MAKE A PROFILE
            ProfileLoader rdfParser = new ProfileLoader();
            Profile profile = rdfParser.LoadProfileDocument(fs, namespc, createCore);
            
            ////GENERATE CLASSES AND ENUMERATIONS
            CodeDOMUtil cdom = new CodeDOMUtil(namespc);
            cdom.Message += new CodeDOMUtil.MessageEventHandler(cdom_Message);
            cdom.GenerateCode(profile);
            ////WRITE FILES
            cdom.WriteFiles(AssemblyVersion);
            ////COMPILE
			if(productName.Equals(string.Empty))
			{
				cdom.CompileCode(fileName + "CIMProfile");
			}
			else
			{
				cdom.CompileCode(fileName + "CIMProfile_" + productName);
			}
            
            return sb;
        }

        
        void cdom_Message(object sender, string message)
        {
            this.sb.Append(message);
        }
    }    
}
