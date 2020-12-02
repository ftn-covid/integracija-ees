using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIMProfileCreator.Utilities
{
    public class PredefinedProperty
    {
        public string URI { get; set; }
        public string type { get; set; }

        public PredefinedProperty(string URI, string type)
        {
            this.URI = URI;
            this.type = type;
        }
    }
}
