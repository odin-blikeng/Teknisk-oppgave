using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.ClassLib
{
    public interface IProjectService
    {
        Task AddNewTimeCard(Guid projectId, Guid driverId, double hours);
        Task<Project[]> GetAllAsync();
        Task<Project> GetOneAsync(Guid projectId);
        Task<string> CheckDriverCredentials(string name, string password);
    }
}