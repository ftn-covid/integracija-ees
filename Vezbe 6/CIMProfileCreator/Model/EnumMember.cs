using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelventDMS.Integration.CIM.Model;

namespace CIMProfileCreator.Model
{
    public class EnumMember : ProfileElement
    {
        protected bool isEnumeration = true;
        //// enum specifics
        protected ProfileElement enumerationObject; //// if this ProfileElement is a value in some Enumeration, this is that Enumeration

        public EnumMember()
            : base("From Derived")
        {

        }

        #region Enumeration specifics
        /// <summary>
        /// Class Specific property.
        /// <para>Gets the indicator whether or not given profile element is enumeration class.</para>
        /// </summary>
        public bool IsEnumeration
        {
            get
            {
                return isEnumeration;
            }
        }

        /// <summary>
        /// Enumeration member Specific property.
        /// <para>Gets and sets the ProfileElement which is the parent class of this enumeration member element.</para>        
        /// </summary>
        public ProfileElement EnumerationObject
        {
            get
            {
                return enumerationObject;
            }
            set
            {
                enumerationObject = value;
            }
        }
        #endregion Enumeration specifics
    }
}
