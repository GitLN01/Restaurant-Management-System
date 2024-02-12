using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderItemBusiness
    {
        private readonly OrderItemRepository orderItemRepository;

        public OrderItemBusiness()
        {
            this.orderItemRepository = new OrderItemRepository();
        }

        public List<Order_Items> GetAllOrderItems()
        {
            return this.orderItemRepository.GetAllOrderItems();
        }

        public bool InsertOrderItems(Order_Items o)
        {
            if (this.orderItemRepository.InsertOrderItems(o) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateOrderItems(Order_Items o)
        {
            if (this.orderItemRepository.UpdateOrderItems(o) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteOrderItems(Order_Items o)
        {
            if (this.orderItemRepository.DeleteOrderItems(o) > 0)
            {
                return true;
            }
            return false;
        }

        public List<Order_Items> GetOrderItemByOrderId(int OrderId)
        {
            return orderItemRepository.GetAllOrderItems().Where(o => o.order_id == OrderId).ToList();
        }
    }
}
