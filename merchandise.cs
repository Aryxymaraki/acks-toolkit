using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACKS_Toolkit
{
    //This is a puny class.  The internet tells me that I shouldn't use a struct if I'm planning to change values.
    public class merchandise
    {
        public string name;
        public double modifier;

        public merchandise(string assign, double value)
        {
            name = assign;
            modifier = value;
        }
    }
}
