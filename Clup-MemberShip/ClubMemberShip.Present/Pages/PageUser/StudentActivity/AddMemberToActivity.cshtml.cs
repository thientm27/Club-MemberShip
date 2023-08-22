using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser.StudentActivity
{
    public class AddMemberToActivityModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public AddMemberToActivityModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public IList<Student> NotAddStudent { get; set; } = default!;
        public IList<Student> AddedStudent { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public int PageIndex1 { get; set; } = 1;
        public int PageSize1 { get; set; } = 3;
        public int TotalPages1;
        [BindProperty(SupportsGet = true)] public int PageIndex2 { get; set; } = 1;
        public int PageSize2 { get; set; } = 3;
        public int TotalPages2;

        public IActionResult OnGet()
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            var activity = HttpContext.Session.GetObjectFromJson<ClubActivity>("ClubActivity");

            var data = _studentServices.GetPagination(PageIndex1 - 1, PageSize1);
            TotalPages1 = data.TotalPagesCount;
            NotAddStudent = (HttpContext.Session.GetObjectFromJson<IList<Student>>("NotAddStudent") ??
                             data.Items.ToList());

            AddedStudent = HttpContext.Session.GetObjectFromJson<IList<Student>>("NotAddStudent") ??
                           new List<Student>();

            return Page();
        }
    }
}