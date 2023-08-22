using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class KickMemberModel : PageModel
    {
        private readonly IMemberShipService _memberShipService;

        public KickMemberModel(IMemberShipService memberShipService)
        {
            _memberShipService = memberShipService;
        }

        [BindProperty] public Membership Membership { get; set; } = default!;

        public IActionResult OnGet(int? studentid, int? clubId)
        {
            if (studentid == null || clubId == null)
            {
                return NotFound();
            }

            var membership = _memberShipService.GetById((int)clubId, (int)studentid);

            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                Membership = membership;
                Membership.QuitDate = DateTime.Today;
            }
           
            return Page();
        }

        public IActionResult OnPost(int? studentid, int? clubId)
        {
            if (studentid == null || clubId == null)
            {
                return NotFound();
            }

            _memberShipService.Delete(Membership.Id);
            return RedirectToPage("./Index");
        }
    }
}