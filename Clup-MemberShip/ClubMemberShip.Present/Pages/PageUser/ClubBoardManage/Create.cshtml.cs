using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class CreateModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public CreateModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Code");
            return Page();
        }

        [BindProperty]
        public ClubBoard ClubBoard { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ClubBoards == null || ClubBoard == null)
            {
                return Page();
            }

            _context.ClubBoards.Add(ClubBoard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
