using App.ClassLib;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data;
public class TimekeepingContext : DbContext
{
    public TimekeepingContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; } =null!;
    public DbSet<Driver> Drivers {get; set;} = null!;
}
