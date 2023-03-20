using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class Vendor
    {
        public int ID { get; set; }
        public int AdminID { set; get; }
		public string Name { set; get; }

        public string Adress { set; get; }

        public string Phone { set; get; }

        public virtual Admin Admin { set; get; } 
    }
}
