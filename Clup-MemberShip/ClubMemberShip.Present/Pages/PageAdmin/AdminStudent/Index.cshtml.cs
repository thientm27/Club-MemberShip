using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminStudent
{
    public class IndexModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages;

        public IndexModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public IList<Student> Student { get; set; } = default!;

        public void OnGet()
        {
            var data = _studentServices.GetPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount ;
            Student = data.Items.ToList();
        }
    }
}