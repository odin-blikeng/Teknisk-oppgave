using System.ComponentModel.DataAnnotations;
using App.ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Drivers;
public class LoginModel : PageModel
{
    private readonly IProjectService ProjectService;

    public LoginModel(IProjectService projectService)
    {
        ProjectService = projectService;
    }

    [BindProperty]
    [Display(Name = "Name")]
    public string? DriverName { get; set; }
    [BindProperty]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    public string Error { get; set; }

    public IActionResult OnGet()
    {
        return Page();

    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (DriverName == null || Password == null) return Page();
        var driverId = await ProjectService.CheckDriverCredentials(DriverName, Password);
        if (driverId == null) return Page();
        if (driverId == "Driver not found" || driverId == "Incorrect password")
        {
            Error = driverId;
            HttpContext.Session.Clear();
            return Page();
        }
         
        HttpContext.Session.SetString("driverId", driverId);
        return RedirectToPage("/Index");
    }
}
