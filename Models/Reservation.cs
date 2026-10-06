using System;

namespace SpiceGardenWebForms.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequest { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
