using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class EditModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IClubServices _clubServices;

        public EditModel(IClubActivityService clubActivityService, IClubServices clubServices)
        {
            _clubActivityService = clubActivityService;
            _clubServices = clubServices;
        }


        [BindProperty] public ClubActivity ClubActivity { get; set; } = default!;

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

            ClubActivity = clubactivity;
            ViewData["ClubId"] = new SelectList(_clubServices.Get(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clubActivityService.Update(ClubActivity);
            return RedirectToPage("./Index");
        }
    }
}