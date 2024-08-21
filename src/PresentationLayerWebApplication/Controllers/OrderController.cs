using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayerWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderBusiness _orderBusiness;

        public OrderController()
        {
            _orderBusiness = new OrderBusiness();
        }

        public IActionResult Index()
        {
            List<Orders> orders = _orderBusiness.GetAllOrders();
            return View(orders);
        }
    }
}
