using System.ComponentModel.DataAnnotations;
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
    [Display(Name = "Number of Hours")]
    public double? NumberOfHours { get; set; }
    public Project Project { get; set; } = null!;

    public async Task<IActionResult> OnGet()
    {
        var str = HttpContext.Session.GetString("projectId");
		if (str == null) return  base.Content($"<h1>Project could not be found</h1>");
        if (Guid.TryParse(str, out var projectId))
        {
            Project = await ProjectService.GetOneAsync(projectId);
        }
        else
        {
            return base.Content($"<h1>Project could not be found</h1>");
        }

        HttpContext.Session.SetString("projectId", projectId.ToString());
        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        // try{
        var str =  HttpContext.Session.GetString("projectId");
		if (str == null) return  base.Content($"<h1>Project cookie has been deleted</h1>");;
		if (Guid.TryParse(str, out var projectId))
            {
            Project = await ProjectService.GetOneAsync(projectId);
		}else{
            return base.Content($"what did you do to the projectid? Please dont play with the cookie.");
        }
        var driverId =  HttpContext.Session.GetString("driverId");
		if (str == null) return  base.Content($"<h1>Project cookie has been deleted</h1>");;
		if (Guid.TryParse(driverId, out var id))
            {
            if( NumberOfHours!=null){
                await ProjectService.AddNewTimeCard(projectId, id, NumberOfHours.Value);
            }
		}else{
            return base.Content($"<h1>Please dont play with the cookie</h1>");
        }

        return Page();
    }
    }
