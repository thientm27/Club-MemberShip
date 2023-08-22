using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class KickMemberModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public KickMemberModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Code");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Code");
            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Memberships == null || Membership == null)
            {
                return Page();
            }

            _context.Memberships.Add(Membership);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
