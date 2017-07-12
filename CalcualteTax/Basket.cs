using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcualteTax
{
    public class Basket
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public List<Items> Items {get;set;}
    }
}
