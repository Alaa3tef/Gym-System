using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class Receptionist
    {
        public int ID { get; set; }
        public int AdminID { get; set; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string Address { set; get; }

        public string Phone { set; get; }

        public int Salary { set; get; }

       public virtual Admin Admin { get; set; }
        public virtual List<Trainee> Trainees { get; set;}
        public virtual List<Coach> Coaches { get; set;}
        public virtual List<ProtienProduct> ProtienProducts { get; set;}
    }
}
