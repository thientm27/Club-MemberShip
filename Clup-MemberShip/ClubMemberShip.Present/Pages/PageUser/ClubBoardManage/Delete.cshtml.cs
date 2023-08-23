using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class DeleteModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;

        public DeleteModel(IClubBoardService clubBoardService)
        {
            _clubBoardService = clubBoardService;
        }

        [BindProperty] public ClubBoard ClubBoard { get; set; } = default!;

        public int ClubId { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubboard = _clubBoardService.GetById(id);

            if (clubboard == null)
            {
                return NotFound();
            }
            else
            {
                ClubBoard = clubboard;
            }

            ClubId = clubboard.ClubId;
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _clubBoardService.Delete(ClubBoard.Id);
            return RedirectToPage("./Index", new { clubid = ClubBoard.ClubId });
        }
    }
}