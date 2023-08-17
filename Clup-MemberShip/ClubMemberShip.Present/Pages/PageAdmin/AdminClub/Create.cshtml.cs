using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;

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

            var result = _clubServices.Add(Club);
            switch (result)
            {
                case Result.Ok:
                    return RedirectToPage("./Index");
                case Result.DuplicatedId:
                    ModelState.AddModelError("Club.Code", "Club code is duplicated");
                    return OnGet();
            }

            return RedirectToPage("./Index");
        }
    }
}