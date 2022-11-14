using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.ClassLib
{
    public class ProjectService : IProjectService
    {
        private TimekeepingContext Db;

        public ProjectService(TimekeepingContext db)
        {
            Db = db;
        }

        public async Task<Project> GetOneAsync(Guid projectId)
        {
            return await Db.Projects.Include(p => p.Hours).SingleOrDefaultAsync(p => p.Id == projectId) ?? throw new Exception("Project not found");
        }

        public async Task<Project[]> GetAllAsync() => await Db.Projects.ToArrayAsync();
        public async Task AddNewTimeCard(Guid projectId, Guid driverId, double hours)
        {
            Project project = await Db.Projects.FindAsync(projectId) ?? throw new Exception("Project not found");
            TimeCard timeCard = new(driverId, hours);
            project.Hours.Add(timeCard);
            await Db.SaveChangesAsync();
        }
        public async Task<string> CheckDriverCredentials(string name, string password)
        {
            var driver = await Db.Drivers.SingleOrDefaultAsync(d => d.Name == name);
            if (driver == null) return "Driver not found";
            if (!BCrypt.Net.BCrypt.Verify(driver.Password, password)) return "Incorrect password";
            return driver.Id.ToString();
        }
    }
}