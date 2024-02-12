using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Items
    {
        public int item_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }
    }
}
