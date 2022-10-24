using App.ClassLib;
using App.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Projects;
public class ProjectIndexModel : PageModel
{
    private readonly IProjectService ProjectService;

    public ProjectIndexModel(IProjectService projectService)
    {
        ProjectService = projectService;
    }


    public Project[] Projects { get; set; } = null!;

    public void OnGet()
    {
        Projects = ProjectService.GetAllAsync().Result.ToArray();
    }

}