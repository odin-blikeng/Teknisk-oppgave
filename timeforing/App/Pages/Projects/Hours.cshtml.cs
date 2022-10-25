using App.ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Projects;
public class HoursModel : PageModel
{
    private readonly IProjectService ProjectService;

    public HoursModel(IProjectService projectService)
    {
        ProjectService = projectService;
    }

    [BindProperty]
    public string? DriverName { get; set; }
    [BindProperty]
    public double? NumberOfHours { get; set; }
    public Project Project { get; set; } = null!;

    public void OnGet()
    {
        var str = HttpContext.Session.GetString("projectId");
		if (str == null) throw new Exception("Project not found");
		if (Guid.TryParse(str, out var projectId))
            {
            Project = ProjectService.GetOneAsync(projectId).Result;
		}
    }
}