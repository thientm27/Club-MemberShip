using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminClubActivity
{
    public class DeleteModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public DeleteModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClubActivity ClubActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClubActivities == null)
            {
                return NotFound();
            }

            var clubactivity = await _context.ClubActivities.FirstOrDefaultAsync(m => m.Id == id);

            if (clubactivity == null)
            {
                return NotFound();
            }
            else 
            {
                ClubActivity = clubactivity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ClubActivities == null)
            {
                return NotFound();
            }
            var clubactivity = await _context.ClubActivities.FindAsync(id);

            if (clubactivity != null)
            {
                ClubActivity = clubactivity;
                _context.ClubActivities.Remove(ClubActivity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
