using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReservationBusiness
    {
        private readonly ReservationRepository reservationRepository;

        public ReservationBusiness()
        {
            this.reservationRepository = new ReservationRepository();
        }

        public List<Reservations> GetAllReservations()
        {
            return this.reservationRepository.GetAllReservations();
        }

        public List<Reservations> GetReservationsByCustomerId(int customerId)
        {
            return reservationRepository.GetAllReservations().Where(reservation => reservation.customer_id == customerId).ToList();
        }

        public Reservations GetReservationById(int reservationId)
        {
            return reservationRepository.GetAllReservations().Where(reservation => reservation.reservation_id == reservationId).FirstOrDefault();
        }

        public bool ExistsReservationWithId(int reservationId)
        {
            return reservationRepository.GetAllReservations().Where(reservation => reservation.reservation_id == reservationId).Any();
        }

        public bool InsertReservations(Reservations r)
        {
            if (this.reservationRepository.InsertReservations(r) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateReservations(Reservations r)
        {
            if (this.reservationRepository.UpdateReservations(r) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteReservations(Reservations r)
        {
            if (this.reservationRepository.DeleteReservations(r) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
