using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminGrade
{
    public class IndexModel : PageModel
    {
        private readonly IGradeService _gradeService;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;
        public int TotalPages;
        public IndexModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        public IList<Grade> Grade { get; set; } = default!;

        public void OnGet()
        {
            var data = _gradeService.GetPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            Grade = data.Items.ToList();
        }
        public IActionResult OnPost()
        {
            OnGet();
            return Page();
        }
    }
}