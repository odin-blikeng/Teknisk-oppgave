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
    public string? DriverId { get; set; }
    [BindProperty]
    public double? NumberOfHours { get; set; }
    public Project Project { get; set; } = null!;

    public async Task<IActionResult> OnGet()
    {
        var str = HttpContext.Session.GetString("projectId");
		if (str == null) throw new Exception("Project not found");
		if (Guid.TryParse(str, out var projectId))
            {
            Project = await ProjectService.GetOneAsync(projectId);
		}
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var str = HttpContext.Session.GetString("projectId");
		if (str == null) throw new Exception("Project not found");
		if (Guid.TryParse(str, out var projectId))
            {
            Project = await ProjectService.GetOneAsync(projectId);
		}

        if (DriverId == null || NumberOfHours == null) return Page();
        Guid driverIdGuid = Guid.Parse(DriverId);
        await ProjectService.AddNewTimeCard(Project.Id, driverIdGuid, NumberOfHours.Value);
        return await OnGet();
    }
}