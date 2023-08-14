using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminGrade
{
    public class EditModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public EditModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        [BindProperty] public Grade Grade { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = _gradeService.GetById(id);
            if (grade == null)
            {
                return NotFound();
            }

            Grade = grade;
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _gradeService.Update(Grade);

            return RedirectToPage("./Index");
        }
    }
}