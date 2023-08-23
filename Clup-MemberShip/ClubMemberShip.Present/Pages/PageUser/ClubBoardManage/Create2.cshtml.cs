using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Web.Pages.PageUser.StudentActivity;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class Create2Model : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IParticipantService _participantService;
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberShipService _memberShipService;
        private readonly IClubServices _clubServices;

        public Create2Model(IStudentServices studentServices, IClubServices clubServices,
            IParticipantService participantService, IClubActivityService clubActivityService,
            IMemberShipService memberShipService)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
            _participantService = participantService;
            _clubActivityService = clubActivityService;
            _memberShipService = memberShipService;
        }

        public IList<Student> Student { get; set; } = default!;

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
            // ignoreList.Add(studentLogin.Id);
            foreach (var o in ignoreList)
            {
                AddedStudent.Add(_studentServices.GetStudentById(o)!);
            }

            var clubBoard = HttpContext.Session.GetObjectFromJson<ClubBoard>("ClubBoard");
            if (clubBoard == null)
            {
                return RedirectToPage("./CreateClubActivity");
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

            // if (id == studentLogin.Id) // remove current
            // {
            //     return OnGet();
            // }

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
            var clubActivity = HttpContext.Session.GetObjectFromJson<ClubActivity>("ClubBoard");


            if (clubActivity == null)
            {
                return RedirectToPage("./Create");
            }

            // var activity = _clubActivityService.AddWithResult(clubActivity);

            // if (activity == null)
            // {
            //     return RedirectToPage("./Create");
            // }

            // addedStudent.List.Add(studentLogin.Id);
            // _participantService.AddMultipleMember(activity.ClubId, activity.Id, addedStudent.List);

            return RedirectToPage("../Index");
        }
    }
}