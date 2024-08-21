using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PresentationLayerWebApplication.Controllers
{
    public class MenuController : Controller
    {
        private readonly ItemBusiness _itemBusiness;

        public MenuController()
        {
            _itemBusiness = new ItemBusiness();
        }

        public IActionResult Index()
        {
            List<Items> items = _itemBusiness.GetAllItems();
            return View(items);
        }
    }
}
