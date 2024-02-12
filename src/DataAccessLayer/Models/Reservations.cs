using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Reservations
    {
        public int reservation_id { get; set; }
        public int customer_id { get; set; }
        public string name { get; set; }
        public int number_of_customers { get; set; }
        public DateTime date { get; set; }
    }
}
