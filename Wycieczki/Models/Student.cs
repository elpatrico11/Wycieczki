using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wycieczki.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
