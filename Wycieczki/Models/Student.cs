using System;
using System.Collections.Generic;

namespace Wycieczki.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
