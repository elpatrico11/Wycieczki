namespace Wycieczki.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string TripName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }




        public ICollection<Destination> Destinations { get; set; }  // A trip can have multiple destinations
    }
}