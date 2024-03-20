namespace Wycieczki.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public DateTime DateOfReservation { get; set; }
    }
}
