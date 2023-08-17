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

        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages;

        public IndexModel(IStudentServices studentServices, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        public IList<Club> Club { get; set; } = default!;
        public Student StudentLogin { get; set; } = default!;

        public void OnGet()
        {
            Authentication();

            var data = _clubServices.GetPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            Club = data.Items.ToList();
        }

        public IActionResult Authentication()
        {
            var id = HttpContext.Session.GetString("User");
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
    }
}