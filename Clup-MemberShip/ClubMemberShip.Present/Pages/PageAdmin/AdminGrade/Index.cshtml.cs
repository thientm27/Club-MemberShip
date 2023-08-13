using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminGrade
{
    public class IndexModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public IndexModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        public IList<Grade> Grade { get; set; } = default!;

        public void OnGet()
        {
            Grade = _gradeService.GetAll() ?? new List<Grade>();
        }
    }
}