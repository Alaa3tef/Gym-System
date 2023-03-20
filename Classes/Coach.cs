using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class Coach
    {
       
        public int ID { set; get; }
        public int AdminID { set; get; }
        public int ReceptionistID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public string Phone { set; get; }

        public int Salary { set; get; }

        public string Gender { set; get; }

        public DateTime Time { set; get; }


        public virtual Receptionist Receptionist { set; get; }
        public virtual Admin Admin { set; get; }

       public virtual List<Trainee> Trainees { set; get; } 
		



    }
}
