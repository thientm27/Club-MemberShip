using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class CreateModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IClubServices _clubServices;

        public CreateModel(IClubActivityService clubActivityService, IClubServices clubServices)
        {
            _clubActivityService = clubActivityService;
            _clubServices = clubServices;
        }


        public IActionResult OnGet()
        {
            ViewData["ClubId"] = new SelectList(_clubServices.Get(), "Id", "Name");
            return Page();
        }

        [BindProperty] public ClubActivity ClubActivity { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clubActivityService.Add(ClubActivity);

            return RedirectToPage("./Index");
        }
    }
}