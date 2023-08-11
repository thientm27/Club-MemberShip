
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor;

public class CreateModel : PageModel
{
    private readonly IMajorService _majorService;

    public CreateModel(IMajorService majorService)
    {
        _majorService = majorService;
    }

    [BindProperty] public Major Major { get; set; } = default!;


    public IActionResult OnGet()
    {
        return Page();
    }


    public IActionResult OnPost()
    {
        var result = _majorService.Add(Major);
        return RedirectToPage("./Index");
    }
}