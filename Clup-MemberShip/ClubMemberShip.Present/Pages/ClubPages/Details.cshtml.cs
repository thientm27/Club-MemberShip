using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Present.Pages.ClubPages
{
    public class DetailsModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public DetailsModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

      public Club Club { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FirstOrDefaultAsync(m => m.Id == id);
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
