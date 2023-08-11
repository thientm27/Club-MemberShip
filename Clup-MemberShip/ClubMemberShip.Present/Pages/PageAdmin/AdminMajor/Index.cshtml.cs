using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor;

public class IndexModel : PageModel
{
    private readonly IMajorService _majorService;

    public IndexModel(IMajorService majorService)
    {
        _majorService = majorService;
    }

    public IList<Major> Major { get; set; } = default!;

    public void OnGet()
    {
        Major = _majorService.GetAll() ?? new List<Major>();
    }
    
    
}