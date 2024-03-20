namespace Wycieczki.Data;
using Microsoft.EntityFrameworkCore;
using Wycieczki.Models;

public class TripsContext : DbContext
{
    public TripsContext(DbContextOptions<TripsContext> options) : base(options)
    {
    }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trip>().ToTable("Trip");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Reservation>().ToTable("Reservation");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("DefaultConnection");
        }
        optionsBuilder.EnableSensitiveDataLogging();
    }

}
