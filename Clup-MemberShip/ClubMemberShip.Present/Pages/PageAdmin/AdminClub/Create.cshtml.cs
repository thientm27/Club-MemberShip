using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClub
{
    public class CreateModel : PageModel
    {
        private readonly IClubServices _clubServices;

        public CreateModel(IClubServices clubServices)
        {
            _clubServices = clubServices;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Club Club { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Club == null)
            {
                return Page();
            }

            _clubServices.Add(Club);

            return RedirectToPage("./Index");
        }
    }
}