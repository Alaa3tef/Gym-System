using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSysyemWpf
{
    public class BuyProtien
    {
        public int ID { get; set; }
        public int AdminID { get; set; }

        public string Name { get; set; }
        public string ProtienName { get; set; }

        public int Quantaty { get; set; }

        public int Price { get; set; }
        public int Total { get; set; }

        public virtual List< ProtienProduct> ProtienProducts { get; set; }
        public virtual Admin Admin { get; set; }

    }
}


