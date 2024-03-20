using System;
using System.Linq;
using Wycieczki.Models; 
using Wycieczki.Data;

namespace Wycieczki.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TripsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any trips.
            if (context.Trips.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Carson", LastName = "Alexander" },
                new Student { FirstName = "Meredith", LastName = "Alonso" },
                new Student { FirstName = "Arturo", LastName = "Anand" },
                // Add more students as needed
            };

            foreach (var student in students)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();

            var destinations = new Destination[]
            {
                new Destination { DestinationName = "Paris", DestinationCountry = "France", TripID = 1 },
                new Destination { DestinationName = "London", DestinationCountry = "UK", TripID = 2 },
                new Destination { DestinationName = "Rome", DestinationCountry = "Italy", TripID = 1 },
               
            };

            foreach (var destination in destinations)
            {
                context.Destinations.Add(destination);
            }

            context.SaveChanges();

            var trips = new Trip[]
            {
                new Trip { TripName = "Summer Vacation", StartDate = DateTime.Parse("2024-06-01"), EndDate = DateTime.Parse("2024-06-15") },
                new Trip { TripName = "Winter Holiday", StartDate = DateTime.Parse("2024-12-20"), EndDate = DateTime.Parse("2025-01-05") },
                new Trip { TripName = "Spring Break", StartDate = DateTime.Parse("2025-03-15"), EndDate = DateTime.Parse("2025-03-30") },
              
            };

            foreach (var trip in trips)
            {
                context.Trips.Add(trip);
            }

            context.SaveChanges();
        }
    }
}
