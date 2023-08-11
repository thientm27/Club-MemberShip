using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor
{
    public class DeleteModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public DeleteModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Major Major { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }

            var major = await _context.Majors.FirstOrDefaultAsync(m => m.Id == id);

            if (major == null)
            {
                return NotFound();
            }
            else 
            {
                Major = major;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }
            var major = await _context.Majors.FindAsync(id);

            if (major != null)
            {
                Major = major;
                _context.Majors.Remove(Major);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
