using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order_Items
    {
        public int order_item_id { get; set; }
        public int customer_id { get; set; }
        public int order_id { get; set;}
        public int item_id { get; set;}
        public int quantity { get; set;}
        public string description { get; set;}
    }
}
