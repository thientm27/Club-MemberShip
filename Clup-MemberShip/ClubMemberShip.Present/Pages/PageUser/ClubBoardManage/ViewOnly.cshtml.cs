using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Web.Pages.PageUser.StudentActivity;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class ViewOnly : PageModel
    {
        private IClubBoardService _clubBoardService;
        private IClubServices _clubServices;
        private IMemberRoleService _memberRoleService;
        private IStudentServices _studentServices;
        public IList<Student> NotAddStudent { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public int PageIndex1 { get; set; } = 1;
        public int PageSize1 { get; set; } = 3;
        public int TotalPages1;

        public ViewOnly(IClubBoardService clubBoardService, IClubServices clubServices,
            IMemberRoleService memberRoleService, IStudentServices studentServices)
        {
            _clubBoardService = clubBoardService;
            _clubServices = clubServices;
            _memberRoleService = memberRoleService;
            _studentServices = studentServices;
        }

        [BindProperty] public ClubBoard ClubBoard { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var clubboard = _clubBoardService.GetById(id);
            if (clubboard == null)
            {
                return NotFound();
            }

            ClubBoard = clubboard;
            ViewData["ClubId"] = new SelectList(_clubServices.Get(), "Id", "Name");


            var data = _memberRoleService.GetPaginationAllMemberOfBoard(PageIndex1 - 1, PageSize1, ClubBoard.Id);
            TotalPages1 = data.TotalPagesCount;
            NotAddStudent = data.Items.ToList();
            return Page();
        }
        
    }
}