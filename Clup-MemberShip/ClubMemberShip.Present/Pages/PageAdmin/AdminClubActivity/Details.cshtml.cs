using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class DetailsModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public DetailsModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        public ClubActivity ClubActivity { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubactivity = _clubActivityService.GetById(id);
            if (clubactivity == null)
            {
                return NotFound();
            }
            else
            {
                ClubActivity = clubactivity;
            }

            return Page();
        }
    }
}