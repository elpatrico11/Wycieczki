namespace Wycieczki.Models
{
    public class Destination
    {
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }

        public string DestinationCountry { get; set; }




        public int TripID { get; set; }  // Foreign key to the Trip
        public Trip Trip { get; set; }   // Navigation property to the Trip
    }
}
