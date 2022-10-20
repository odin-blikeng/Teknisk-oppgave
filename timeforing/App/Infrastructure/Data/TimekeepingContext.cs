using App.ClassLib;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data;
public class TimekeepingContext : DbContext
{
    public TimekeepingContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; } =null!;
    public DbSet<Driver> Drivers {get; set;} = null!;
}


public class DatabaseSeed
{
    public DatabaseSeed(TimekeepingContext db)
    {
        Context = db;
    }

    private TimekeepingContext Context{get; init;}
    private readonly List<string> Projects = new List<string> { "Project 1", "Project 2", "Project 3" };
    private readonly List<string> Drivers = new List<string> { "Driver 1", "Driver 2", "Driver 3" };

    public void Seed()
    {
            foreach (var project in Projects)
            {
                Context.Projects.Add(new Project(project));
            }
            Context.SaveChanges();


            foreach (var driver in Drivers)
            {
                Context.Drivers.Add(new Driver(driver));
            }
            Context.SaveChanges();

    }

}
