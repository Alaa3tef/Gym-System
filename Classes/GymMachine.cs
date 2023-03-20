using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class GymMachine
    {
        public int ID { get; set; }
        public int AdminID { set; get; }
		public string Name { set; get; }
        public int Price { set; get; }
        public virtual Admin Admin { set; get; }

    }
}
