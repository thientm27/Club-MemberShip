using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor;

public class DetailsModel : PageModel
{
    private readonly IMajorService _majorService;

    public DetailsModel(IMajorService majorService)
    {
        _majorService = majorService;
    }

    public Major Major { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id != null)
        {
            var major = _majorService.GetById(id);
            if (major == null)
            {
                return NotFound();
            }

            Major = major;
        }

        return Page();
    }
}