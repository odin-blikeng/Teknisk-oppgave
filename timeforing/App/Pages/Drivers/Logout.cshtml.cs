using System.ComponentModel.DataAnnotations;
using App.ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Drivers;
public class LogoutModel : PageModel
{
    public LogoutModel()
    {
    }



    public IActionResult OnGet()
    {
        HttpContext.Session.Clear();
        return RedirectToPage("/Index");

    }
}
