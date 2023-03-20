using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class ProtienProduct
    {
		public int ID { get; set; }

		public string Name { set; get; }
		public int AdminID { set; get; }
		public int ReceptionistID { set; get; }
		public int Quantaty { set; get; }
        public int Price { set; get; }

		public double Total { get; set; }

		public virtual Admin Admin { set; get; }

		public virtual Receptionist Receptionist { set; get; }

       

    }
}
