using System.Net;
using App.ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProjectService ProjectService;

    public IndexModel(ILogger<IndexModel> logger, IProjectService projectService)
    {
        ProjectService = projectService;
        _logger = logger;
    }


    public Project[] Projects { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        Projects = await ProjectService.GetAllAsync();
        
        var driverId = HttpContext.Session.GetString("driverId");
        if (driverId == null) return RedirectToPage("/Drivers/Login");
        else return Page();
    }

    public IActionResult OnPostGoToProject(string Id){
        HttpContext.Session.SetString("projectId", Id);
        return RedirectToPage("Projects/Hours");
    }

}