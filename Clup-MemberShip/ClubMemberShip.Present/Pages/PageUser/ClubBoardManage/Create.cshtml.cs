using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser.ClubBoardManage
{
    public class CreateModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IStudentServices _studentServices;
        private readonly IClubServices _clubServices;

        public CreateModel(IClubBoardService clubBoardService, IStudentServices studentServices,
            IClubServices clubServices)
        {
            _clubBoardService = clubBoardService;
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        public int ClubId { get; set; }

        public IActionResult OnGet(int? clubId)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            if (clubId == null)
            {
                return RedirectToPage("../Index");
            }

            ClubId = (int)clubId;
            var tempList = new List<Club>();
            tempList.Add(_clubServices.GetById(ClubId)!);
            ViewData["ClubId"] = new SelectList(tempList, "Id", "Name");

            return Page();
        }

        [BindProperty] public ClubBoard ClubBoard { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (ClubBoard == null)
            {
                return Page();
            }

            HttpContext.Session.SetObjectAsJson("ClubBoard", ClubBoard);

            return RedirectToPage("./Index");
        }
    }
}