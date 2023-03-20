using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class Trainee
    {
        public int ID { set; get; }
        public int AdminID { set; get; }
        public int ReceptionistID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public string Phone { set; get; }

        public int Age { set; get; }

        public string Gender { set; get; }

        public DateTime Time { set; get; }

        public string Subscription { set; get; }
        public int price { set; get; }

      

        public virtual Admin Admin { set; get; }
        public virtual Receptionist Receptionist {set; get; }
       
    }

}
