using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class IndexModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;
        public int TotalPages;

        public IndexModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        public IList<ClubActivity> ClubActivity { get; set; } = default!;

        public void OnGet()
        {
            var data = _clubActivityService.GetPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            ClubActivity = data.Items.ToList();
        }
    }
}