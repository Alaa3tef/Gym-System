using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class Admin
    {
        public int ID { get; set; }
        public string UserName { set; get; }
        public string Password { set; get; }

        public virtual List<Receptionist> Receptionists { get; set; }
        public virtual List<Trainee> Trainees { get; set; }
        public virtual List<Coach> Coaches { get; set; }
        public virtual List<ProtienProduct> ProtienProducts { get; set; }
        public virtual List<GymMachine> Machines { get; set; }
        public virtual List<Vendor> Vendors { get; set; }



    }
}
