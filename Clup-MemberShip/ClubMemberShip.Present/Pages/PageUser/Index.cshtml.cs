using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class IndexModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IClubServices _clubServices;

        [BindProperty(SupportsGet = true, Name = "PageIndexA")]
        public int PageIndexJoinedClub { get; set; } = 1;

        public int PageSizeJoinedClub { get; set; } = 3;
        public int TotalPagesJoinedClub;

        [BindProperty(SupportsGet = true, Name = "PageIndexB")]
        public int PageIndexAvailableClub { get; set; } = 1;

        public int PageSizeAvailableClub { get; set; } = 3;
        public int TotalPagesAvailableClub;

        public IndexModel(IStudentServices studentServices, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        public IList<Club> JoinedClub { get; set; } = default!;
        public IList<Club> AvailableClub { get; set; } = default!;
        public Student StudentLogin { get; set; } = default!;

        public IActionResult OnGet()
        {
            var id = HttpContext.Session.GetString("User");
            Authentication(id);

            var data = _clubServices.GetJoinedClub(PageIndexJoinedClub - 1, PageSizeJoinedClub, StudentLogin.Id);
            if (data != null)
            {
                TotalPagesJoinedClub = data.TotalPagesCount;
                JoinedClub = data.Items.ToList();
            }
            else
            {
                JoinedClub = new List<Club>();
            }

            var data2 = _clubServices.GetAvailableClub(PageIndexAvailableClub - 1, PageSizeAvailableClub,
                StudentLogin.Id);
            TotalPagesAvailableClub = data2.TotalPagesCount;
            AvailableClub = data2.Items.ToList();
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return OnGet();
            }

            var studentId = HttpContext.Session.GetString("User");
            Authentication(studentId);

            _studentServices.RegisterToClub(new Membership
            {
                StudentId = StudentLogin.Id,
                ClubId = (int)id,
                JoinDate = null,
                QuitDate = null,
                NickName = StudentLogin.Name,
            });
            
            return OnGet();
        }

        public IActionResult Authentication(string? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Login");
            }

            var studentLogin = _studentServices.GetById(id);
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            StudentLogin = studentLogin;
            return Page();
        }

        public bool CheckRegister(int clubId)
        {
            return _studentServices.CheckRegisterToClub(StudentLogin.Id, clubId);
        }
    }
}