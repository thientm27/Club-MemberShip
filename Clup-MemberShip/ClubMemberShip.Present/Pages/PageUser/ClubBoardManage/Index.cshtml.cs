using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class IndexModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IStudentServices _studentServices;

        public IndexModel(IClubBoardService clubBoardService, IStudentServices studentServices)
        {
            _clubBoardService = clubBoardService;
            _studentServices = studentServices;
        }

        public IList<ClubBoard> ClubBoard { get; set; } = default!;
        public int ClubId { get; set; }

        public IActionResult OnGetAsync(int? clubid)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            if (clubid == null)
            {
                return RedirectToPage("../Index");
            }

            ClubId = (int)clubid;
            ClubBoard = _clubBoardService.GetByClubId((int)clubid);
            
            return Page();
        }
    }
}