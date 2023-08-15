using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClub
{
    public class DeleteModel : PageModel
    {
        private readonly IClubServices _clubServices;

        public DeleteModel(IClubServices clubServices)
        {
            _clubServices = clubServices;
        }

        [BindProperty] public Club Club { get; set; } = default!;

        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = _clubServices.GetById(id);

            if (club == null)
            {
                return NotFound();
            }
            else
            {
                Club = club;
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = _clubServices.GetById(id);

            if (club != null)
            {
                Club = club;
                _clubServices.Delete(Club);
            }

            return RedirectToPage("./Index");
        }
    }
}