using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelConverter
{
    class BasicConversions
    {
        public static bool StrToInt(string str, out int num)
        {/*
            num = -1;
            try
            {
                num = Int32.Parse(str);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
           */

            return Int32.TryParse(str, out num);
        }
    }
}
