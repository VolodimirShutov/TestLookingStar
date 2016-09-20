using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace star1
{
    class Element
    {
        public string name { get; set; }
        public int line { get; set; }
        public int position { get; set; }
        public int value { get; set; }
        
        public int pathValue { get; set; }
        public string parentElementName { get; set; }
    }
}
