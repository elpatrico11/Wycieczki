using Wycieczki.Models;

namespace Wycieczki.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TripsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{  FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("2002-09-01")},
                new Student{ FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("2003-09-01")},
                new Student{ FirstName="Gytis",LastName="Barzdukas",DateOfBirth=DateTime.Parse("2002-09-01")},
                //new Student{FirstName="Yan",LastName="Li",DateOfBirth=DateTime.Parse("2002-09-01")},
                //new Student{FirstName="Peggy",LastName="Justice",DateOfBirth=DateTime.Parse("2001-09-01")},
                //new Student{FirstName="Laura",LastName="Norman",DateOfBirth=DateTime.Parse("2003-09-01")},
                //new Student{FirstName="Nino",LastName="Olivetto",DateOfBirth=DateTime.Parse("2005-09-01")}
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var trips = new Trip[]
            {
                new Trip{Name="Wycieczka 1",Date=DateTime.Parse("2021-09-01"),Price=Decimal.Parse("100")},
                new Trip{Name="Wycieczka 2",Date=DateTime.Parse("2021-09-01"),Price=Decimal.Parse("200")},
                new Trip{Name="Wycieczka 3",Date=DateTime.Parse("2021-09-01"),Price=Decimal.Parse("300")},
                new Trip{Name="Wycieczka 4",Date=DateTime.Parse("2021-09-01"),Price=Decimal.Parse("400")},
                new Trip{Name="Wycieczka 5",Date=DateTime.Parse("2021-09-01"),Price=Decimal.Parse("500")}
            };

            foreach (Trip c in trips)
            {
                context.Trips.Add(c);
            }
            context.SaveChanges();

            // Pobieramy zaktualizowane encje ze zmianami ID z bazy danych
            var updatedStudents = context.Students.ToList();
            var updatedTrips = context.Trips.ToList();

            var reservations = new Reservation[]
            {
                new Reservation{StudentId=updatedStudents[0].StudentId,TripId=updatedTrips[0].TripId,DateOfReservation=DateTime.Parse("2021-09-01")},
                new Reservation{StudentId=updatedStudents[1].StudentId,TripId=updatedTrips[2].TripId,DateOfReservation=DateTime.Parse("2021-09-01")},
                new Reservation{StudentId=updatedStudents[1].StudentId,TripId=updatedTrips[1].TripId,DateOfReservation=DateTime.Parse("2021-09-01")},
                new Reservation{StudentId=updatedStudents[2].StudentId,TripId=updatedTrips[1].TripId,DateOfReservation=DateTime.Parse("2021-09-01")}
            };

            foreach (Reservation reservation in reservations)
            {
                context.Add(reservation);
            }
            context.SaveChanges();
        }
    }
}
