using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class AddNewMemberModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IClubServices _clubServices;

        public AddNewMemberModel(IStudentServices studentServices, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        [BindProperty] public Membership Membership { get; set; } = default!;

        public IActionResult OnGet(int? id, int? clubId)
        {
            if (id == null || clubId == null)
            {
                return NotFound();
            }


            var membership = _studentServices.GetMemberShipByClubIdAndStudentId((int)id, (int)clubId);
            if (membership == null)
            {
                return NotFound();
            }

            Membership = membership;
            ViewData["ClubId"] = new SelectList(_clubServices.Get(), "Id", "Name");
            ViewData["StudentId"] = new SelectList(_studentServices.Get(), "Id", "Name");
            return Page();
        }

        public IActionResult OnPostApprove()
        {
            Membership.Status = Status.Active;
            _clubServices.UpdateMembership(Membership);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostReject()
        {
            Membership.Status = Status.Na;
            _clubServices.UpdateMembership(Membership);
            return RedirectToPage("./Index");
        }
    }
}