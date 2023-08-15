using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClub
{
    public class DetailsModel : PageModel
    {
        private readonly IClubServices _clubServices;

        public DetailsModel(IClubServices clubServices)
        {
            _clubServices = clubServices;
        }

        public Club Club { get; set; } = default!; 

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
    }
}
