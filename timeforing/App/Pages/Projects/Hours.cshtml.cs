using App.ClassLib;
using App.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Projects;
public class HoursModel : PageModel
{
    private readonly IProjectService ProjectService;

    public HoursModel(IProjectService projectService)
    {
        ProjectService = projectService;
    }


    public Project Project { get; set; } = null!;

    public void OnGet(Guid projectId)
    {
        Project = ProjectService.GetOneAsync(projectId).Result;
    }

}