using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor;

public class EditModel : PageModel
{
    private readonly IMajorService _majorService;

    public EditModel(IMajorService majorService)
    {
        _majorService = majorService;
    }

    [BindProperty] public Major Major { get; set; } = default!;

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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _majorService.Update(Major);
        return RedirectToPage("./Index");
    }
}