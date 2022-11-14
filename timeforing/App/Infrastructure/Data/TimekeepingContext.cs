using App.ClassLib;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data;
public class TimekeepingContext : DbContext
{
    public TimekeepingContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; } =null!;
    public DbSet<Driver> Drivers {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .OwnsMany(p => p.Hours, h =>{
                h.WithOwner().HasForeignKey("ProjectId");
                h.Property(h => h.Id).HasColumnName("TimeCardId");
            });
    }
}


public class DatabaseSeed
{
    public DatabaseSeed(TimekeepingContext db)
    {
        Context = db;
    }

    private TimekeepingContext Context{get; init;}
    private readonly List<string> ProjectList = new List<string> { "Nortura", "Circle K", "Sandnes Kommune" };
    private readonly List<string> DriverList = new List<string> { "Kåre Jakobsen", "Jonas Torseth", "Even Lauritzen", "Ola Normann"};
    private readonly List<string> PasswordList = new List<string> { "Ec64xn2XG%aB5dyR", "3K6&b8us^nIaXjVI", "!E^5^ymnNW8AL7AY", "qvLwJE9VjN3!F45m" };
    public void Seed()
    {
            foreach (var project in ProjectList)
            {
                Context.Projects.Add(new Project(project));
            }

            foreach (var driver in DriverList.Select((e, i) => new { Value = e, Index = i }))
            {
                Context.Drivers.Add(new Driver(driver.Value, PasswordList[driver.Index]));
            }
            Context.SaveChanges();
            
            foreach(var project in Context.Projects.ToArray())
            {
                project.AddHours(Context.Drivers.First().Id, 1.5);
                project.AddHours(Context.Drivers.Skip(1).First().Id, 2.5);
                project.AddHours(Context.Drivers.Skip(2).First().Id, 3.5);
            }
            Context.SaveChanges();
    }
}
