using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;

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
        switch (result)
        {
            case Result.Ok:
                return RedirectToPage("./Index");
            case Result.DuplicatedId:
                ModelState.AddModelError("Major.Code", "Major code is duplicated");
                return OnGet();
        }

        return RedirectToPage("./Index");
    }
}