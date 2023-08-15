using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClub
{
    public class IndexModel : PageModel
    {
        private readonly IClubServices _clubServices;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages;

        public IndexModel(IClubServices clubServices)
        {
            _clubServices = clubServices;
        }

        public IList<Club> Club { get; set; } = default!;

        public void OnGet()
        {
            var data = _clubServices.GetPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            Club = data.Items.ToList();
        }
    }
}