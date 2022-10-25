using App.ClassLib;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> OnGetAsync()
    {
        Projects = await ProjectService.GetAllAsync();
        return Page();
    }

    public IActionResult OnPostGoToProject(string Id){
        HttpContext.Session.SetString("projectId", Id);
        return RedirectToPage("Hours");
    }

}