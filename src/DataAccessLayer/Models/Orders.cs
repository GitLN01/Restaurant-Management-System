using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Orders
    {
        public int order_id { get; set; }
        public int customer_id { get; set;}
        public DateTime time { get; set;}
        public int table_number { get; set;}
    }
}
