using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Wycieczki.Models
{
    public class Reservation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public DateTime DateOfReservation { get; set; }

        //data od kiedy do kiedy
        //cena laczna
        //ilosc osob
        //data oplacenia ktora jest nullem (jesli nie zostala oplacona to jest nullem, jesli jest oplacona, to dostaje date)
    }
}
