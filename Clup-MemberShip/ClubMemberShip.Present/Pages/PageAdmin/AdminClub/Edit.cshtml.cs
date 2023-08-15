using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClub
{
    public class EditModel : PageModel
    {
        private readonly IClubServices _clubServices;

        public EditModel(IClubServices clubServices)
        {
            _clubServices = clubServices;
        }


        [BindProperty]
        public Club Club { get; set; } = default!;

        public IActionResult OnGet(int? id)
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
            Club = club;
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

            _clubServices.Update(Club);

            return RedirectToPage("./Index");
        }
        
    }
}
