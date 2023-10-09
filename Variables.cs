using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop1
{
    public class Variables
    {
        private static string name = "";
        public static string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
