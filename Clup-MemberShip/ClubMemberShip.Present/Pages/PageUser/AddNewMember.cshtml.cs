using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = _studentServices.GetMemberShipById((int)id);
            if (membership == null)
            {
                return NotFound();
            }

            Membership = membership;
            ViewData["ClubId"] = new SelectList(_clubServices.Get(), "Id", "Code");
            ViewData["StudentId"] = new SelectList(_studentServices.Get(), "Id", "Code");
            return Page();
        }

        public IActionResult OnPostApprove()
        {
            Membership.Status = Status.Active;

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostReject()
        {
            Membership.Status = Status.Na;
            return RedirectToPage("./Index");
        }
    }
}