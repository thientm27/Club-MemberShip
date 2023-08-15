using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor;

public class IndexModel : PageModel
{
    private readonly IMajorService _majorService;

    [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
    public int Count { get; set; }
    public int PageSize { get; set; } = 3;
    public int TotalPages;

    public IndexModel(IMajorService majorService)
    {
        _majorService = majorService;
    }

    public IList<Major> Major { get; set; } = default!;

    public void OnGet()
    {
        var data = _majorService.GetPagination(PageIndex - 1, PageSize);
        TotalPages = data.TotalPagesCount;
        Major = data.Items.ToList();
    }

    public IActionResult OnPost()
    {
        OnGet();
        return Page();
    }
}