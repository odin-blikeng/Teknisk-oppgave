using App.ClassLib;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data;
public class TimekeepingContext : DbContext
{
    public TimekeepingContext(DbContextOptions options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
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
    private readonly List<string> ProjectList = new List<string> { "Project 1", "Project 2", "Project 3" };
    private readonly List<string> DriverList = new List<string> { "Driver 1", "Driver 2", "Driver 3" };

    public void Seed()
    {
            foreach (var project in ProjectList)
            {
                Context.Projects.Add(new Project(project));
            }
            Context.SaveChanges();

            foreach (var driver in DriverList)
            {
                Context.Drivers.Add(new Driver(driver));
            }
            Context.SaveChanges();

            foreach(var project in Context.Projects)
            {
                project.AddHours(Context.Drivers.First().Id, 1.5);
                project.AddHours(Context.Drivers.Skip(1).First().Id, 2.5);
                project.AddHours(Context.Drivers.Skip(2).First().Id, 3.5);
            }
            Context.SaveChanges();
    }
}
