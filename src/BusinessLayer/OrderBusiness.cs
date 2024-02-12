using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderBusiness
    {
        private readonly OrderRepository orderRepository;

        public OrderBusiness()
        {
            this.orderRepository = new OrderRepository();
        }

        public List<Orders> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }

        public bool InsertOrders(Orders o)
        {
            if (this.orderRepository.InsertOrders(o) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateOrders(Orders o)
        {
            if (this.orderRepository.UpdateOrders(o) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteOrders(Orders o)
        {
            if (this.orderRepository.DeleteOrders(o) > 0)
            {
                return true;
            }
            return false;
        }

        public Orders GetLatestOrder()
        {
            return this.orderRepository.GetAllOrders().OrderByDescending(o => o.time).FirstOrDefault();
        }

        public List<Orders> GetOrdersByCustomerId(int CustomerId)
        {
            return this.orderRepository.GetAllOrders().Where(order => order.customer_id == CustomerId).ToList();
        }
    }
}
