using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Web.Pages.PageUser.StudentActivity;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class Edit2 : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IClubServices _clubServices;
        private readonly IClubBoardService _clubBoardService;
        private readonly IMemberRoleService _memberRoleService;


        public Edit2(IStudentServices studentServices, IClubServices clubServices,
            IClubBoardService clubBoardService, IMemberRoleService memberRoleService)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
            _clubBoardService = clubBoardService;
            _memberRoleService = memberRoleService;
        }


        public IList<Student> NotAddStudent { get; set; } = default!;
        public IList<Student> AddedStudent { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public int PageIndex1 { get; set; } = 1;
        public int PageSize1 { get; set; } = 3;
        public int TotalPages1;

        public IActionResult OnGet()
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            AddedStudent = new List<Student>();
            var sessionData = HttpContext.Session.GetObjectFromJson<AddedStudentObject>("AddedStudent") ??
                              new AddedStudentObject();

            var ignoreList = sessionData.List;
            foreach (var o in ignoreList)
            {
                AddedStudent.Add(_studentServices.GetStudentById(o)!);
            }

            var clubBoard = HttpContext.Session.GetObjectFromJson<ClubBoard>("ClubBoard");
            if (clubBoard == null)
            {
                return RedirectToPage("./Index", new { clubId = clubBoard.ClubId });
            }

            var data = _clubServices.GetStudentInClub(PageIndex1 - 1, PageSize1, clubBoard.ClubId, ignoreList);
            TotalPages1 = data.TotalPagesCount;
            NotAddStudent = data.Items.ToList();

            return Page();
        }

        public IActionResult OnPostAdd(int? id)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            var studentAdded = _studentServices.GetStudentById((int)id);
            if (studentAdded == null)
            {
                return NotFound();
            }

            var sessionData = HttpContext.Session.GetObjectFromJson<AddedStudentObject>("AddedStudent") ??
                              new AddedStudentObject();
            sessionData.List.Add((int)id);
            HttpContext.Session.SetObjectAsJson("AddedStudent", sessionData);

            return OnGet();
        }

        public IActionResult OnPostRemove(int? id)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            var studentAdded = _studentServices.GetStudentById((int)id);
            if (studentAdded == null)
            {
                return NotFound();
            }

            var sessionData = HttpContext.Session.GetObjectFromJson<AddedStudentObject>("AddedStudent") ??
                              new AddedStudentObject();
            sessionData.List.Remove((int)id);
            HttpContext.Session.SetObjectAsJson("AddedStudent", sessionData);

            return OnGet();
        }

        public IActionResult OnPostSubmit()
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            var addedStudent = HttpContext.Session.GetObjectFromJson<AddedStudentObject>("AddedStudent") ??
                               new AddedStudentObject();
            var clubBoard = HttpContext.Session.GetObjectFromJson<ClubBoard>("ClubBoard");

            if (clubBoard == null)
            {
                return RedirectToPage("./Create");
            }

     
            var originList = _memberRoleService.GetAllMemberOfBoard(clubBoard.Id);
            var originIds = originList.Select(o => o.Id).ToList();
            _memberRoleService.RemoveMultipleMember(clubBoard.ClubId, clubBoard.Id, originIds);
            _memberRoleService.AddMultipleMember(clubBoard.ClubId, clubBoard.Id, addedStudent.List);
            return RedirectToPage("./Index", new { clubId = clubBoard.ClubId });
        }
    }
}