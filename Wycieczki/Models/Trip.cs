using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Wycieczki.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
