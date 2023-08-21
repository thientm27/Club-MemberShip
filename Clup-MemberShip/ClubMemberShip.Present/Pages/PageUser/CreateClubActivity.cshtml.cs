using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser
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

        public IActionResult OnGet(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            ClubActivity = new();
            ClubActivity.TimeLine = TimeLineStatus.Pending;
            ViewData["ClubId"] = new SelectList(_clubServices.GetJoinedClub(studentLogin.Id), "Id", "Name");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clubActivityService.Add(ClubActivity);
            return RedirectToPage("./Index");
        }
    }
}