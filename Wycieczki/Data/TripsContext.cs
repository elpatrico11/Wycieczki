namespace Wycieczki.Data;
using Wycieczki.Models;
using Microsoft.EntityFrameworkCore;

public class TripsContext : DbContext
{
    public TripsContext(DbContextOptions<TripsContext> options) : base(options)
    {

    }

    public DbSet<Trip> Trips { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trip>().ToTable("Trip");
        modelBuilder.Entity<Destination>().ToTable("Destination");
        modelBuilder.Entity<Student>().ToTable("Student");
    }
}
