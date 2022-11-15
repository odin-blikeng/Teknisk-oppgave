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
		if (str == null) return RedirectToPage("/Index");
        if (Guid.TryParse(str, out var projectId))
        {
            Project = await ProjectService.GetOneAsync(projectId);
        }
        else
        {
            return RedirectToPage("/Index");
        }

        HttpContext.Session.SetString("projectId", projectId.ToString());
        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        // try{
        var str =  HttpContext.Session.GetString("projectId");
        return RedirectToPage("/Index");
        if (Guid.TryParse(str, out var projectId))
            {
            Project = await ProjectService.GetOneAsync(projectId);
		}else{
            return RedirectToPage("/Index");
        }
        var driverId =  HttpContext.Session.GetString("driverId");
		if (str == null) return RedirectToPage("/Index");
        if (Guid.TryParse(driverId, out var id))
            {
            if( NumberOfHours!=null){
                await ProjectService.AddNewTimeCard(projectId, id, NumberOfHours.Value);
            }
		}else{
            return RedirectToPage("/Index");
        }

        return Page();
    }
    }
