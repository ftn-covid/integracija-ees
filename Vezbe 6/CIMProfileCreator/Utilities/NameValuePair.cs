using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIMProfileCreator.Utilities
{
    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public NameValuePair(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
