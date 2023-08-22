using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubMemberShip.Web.Pages.PageUser.StudentActivity
{
    public class CreateClubActivityModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IClubServices _clubServices;
        private readonly IStudentServices _studentServices;
        [BindProperty] public ClubActivity ClubActivity { get; set; } = default!;

        public CreateClubActivityModel(IClubActivityService clubActivityService, IClubServices clubServices,
            IStudentServices studentServices)
        {
            _clubActivityService = clubActivityService;
            _clubServices = clubServices;
            _studentServices = studentServices;
        }

        public IActionResult OnGet()
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            ClubActivity = new();
            ClubActivity.TimeLine = TimeLineStatus.Pending;

            var joinedList = _clubServices.GetJoinedClub(studentLogin.Id);
            if (joinedList == null || joinedList.Count == 0)
            {
                return RedirectToPage("../Index");
            }

            ViewData["ClubId"] = new SelectList(joinedList, "Id", "Name");
            return Page();
        }

        public IActionResult OnPost()
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            if (ClubActivity.StartDay > ClubActivity.EndDay)
            {
                ModelState.AddModelError("ClubActivity.StartDay", "Start day must be < End day");
                ModelState.AddModelError("ClubActivity.EndDay", "End day must be > Start day");
                return OnGet();
            }

            // HttpContext.Session.Set();
            // var result = _clubActivityService.Add(ClubActivity);
            return RedirectToPage("../Index");
        }
    }
}