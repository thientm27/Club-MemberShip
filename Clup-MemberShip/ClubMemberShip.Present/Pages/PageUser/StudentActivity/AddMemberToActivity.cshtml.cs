using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser.StudentActivity
{
    public class AddMemberToActivityModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IParticipantService _participantService;
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberShipService _memberShipService;
        private readonly IClubServices _clubServices;

        public AddMemberToActivityModel(IStudentServices studentServices, IParticipantService participantService,
            IClubActivityService clubActivityService, IMemberShipService memberShipService, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _participantService = participantService;
            _clubActivityService = clubActivityService;
            _memberShipService = memberShipService;
            _clubServices = clubServices;
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
            ignoreList.Add(studentLogin.Id);
            foreach (var o in ignoreList)
            {
                AddedStudent.Add(_studentServices.GetStudentById(o)!);
            }

            var clubActivity = HttpContext.Session.GetObjectFromJson<ClubActivity>("ClubActivity");
            if (clubActivity == null)
            {
                return RedirectToPage("./CreateClubActivity");
            }

            var data = _clubServices.GetStudentInClub(PageIndex1 - 1, PageSize1, clubActivity.ClubId, ignoreList);
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

            if (id == studentLogin.Id) // remove current
            {
                return OnGet();
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

            var addedStudent = HttpContext.Session.GetObjectFromJson<AddedStudentObject>("AddedStudent") ?? new AddedStudentObject();
            var clubActivity = HttpContext.Session.GetObjectFromJson<ClubActivity>("ClubActivity");


            if (clubActivity == null)
            {
                return RedirectToPage("./CreateClubActivity");
            }

            var activity = _clubActivityService.AddWithResult(clubActivity);

            if (activity == null)
            {
                return RedirectToPage("./CreateClubActivity");
            }

            addedStudent.List.Add(studentLogin.Id);
            _participantService.AddMultipleMember(activity.ClubId, activity.Id, addedStudent.List);

            return RedirectToPage("../Index");
        }
    }

    public class AddedStudentObject
    {
        public List<int> List { get; set; } = new();
    }
}