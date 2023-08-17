using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class DeleteModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public DeleteModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        [BindProperty] public ClubActivity ClubActivity { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null )
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

        public IActionResult OnPost(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var clubactivity = _clubActivityService.GetById(id);

            if (clubactivity != null)
            {
                ClubActivity = clubactivity;
                _clubActivityService.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}