using System;
using System.Collections.Generic;
using SpiceGardenWebForms.DAL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.BLL
{
    public class ReservationBLL
    {
        private readonly ReservationDAL reservationDal;
        public ReservationBLL() { reservationDal = new ReservationDAL(); }
        public int AddReservation(Reservation reservation)
        {
            if (reservation.NumberOfGuests < 1 || reservation.NumberOfGuests > 20) throw new ArgumentException("Number of guests must be between 1 and 20.");
            if (reservation.ReservationDate < DateTime.Today) throw new ArgumentException("Reservation date cannot be in the past.");
            reservation.Status = "Pending";
            return reservationDal.Insert(reservation);
        }
        public List<Reservation> GetReservations(string search = null) { return reservationDal.GetReservations(search); }
        public List<Reservation> GetUserReservations(int userId) { return reservationDal.GetUserReservations(userId); }
        public void UpdateStatus(int id, string status) { reservationDal.UpdateStatus(id, status); }
    }
}
