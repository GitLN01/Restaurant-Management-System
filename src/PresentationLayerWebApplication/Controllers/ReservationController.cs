using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PresentationLayerWebApplication.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationBusiness _reservationBusiness;

        public ReservationController()
        {
            _reservationBusiness = new ReservationBusiness();
        }

        public IActionResult Index()
        {
            List<Reservations> reservations = _reservationBusiness.GetAllReservations();
            return View(reservations);
        }
    }
}
