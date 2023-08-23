using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class DetailsModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public DetailsModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

      public ClubBoard ClubBoard { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClubBoards == null)
            {
                return NotFound();
            }

            var clubboard = await _context.ClubBoards.FirstOrDefaultAsync(m => m.Id == id);
            if (clubboard == null)
            {
                return NotFound();
            }
            else 
            {
                ClubBoard = clubboard;
            }
            return Page();
        }
    }
}
