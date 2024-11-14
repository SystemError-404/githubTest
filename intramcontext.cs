using Intrams.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class IntramsContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Sports> Sports { get; set; }
    public DbSet<Location> Locations { get; set; }

    public IntramsContext(DbContextOptions<IntramsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Jafar", Email = "jafar@s.msumain.edu.ph", SchoolId = 202212121, EventId = 1, SportId = 1 },
            new Player { Id = 2, Name = "Ramzi", Email = "ramzi@s.msumain.edu.ph", SchoolId = 202212123, EventId = 2, SportId = 2 },
            new Player { Id = 3, Name = "Hakim", Email = "hakim@s.msumain.edu.ph", SchoolId = 202212133, EventId = 1, SportId = 2 }
        );

        modelBuilder.Entity<Event>().HasData(
            new Event { Id = 1, Title = "Football Match", DateTime = DateTime.Now.AddDays(7), LocationId = 1 },
            new Event { Id = 2, Title = "Basketball Tournament", DateTime = DateTime.Now.AddDays(14), LocationId = 2 }
        );

        modelBuilder.Entity<Sports>().HasData(
            new Sports { Id = 1, SportsName = "Football" },
            new Sports { Id = 2, SportsName = "Basketball" },
            new Sports { Id = 3, SportsName = "Chess" }
        );

        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Name = "Stadium A", Address = "Dimaporo"},
            new Location { Id = 2, Name = "Arena B", Address = "Grandstand"}
        );
    }
}
