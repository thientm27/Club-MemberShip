using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminStudent
{
    public class EditModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IGradeService _gradeService;
        private readonly IMajorService _majorService;

        public EditModel(IStudentServices studentServices, IGradeService gradeService, IMajorService majorService)
        {
            _studentServices = studentServices;
            _gradeService = gradeService;
            _majorService = majorService;
        }

        [BindProperty] public Student Student { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentServices.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            Student = student;

            ViewData["GradeId"] = new SelectList(_gradeService.Get(), "Id", "GradeYear");
            ViewData["MajorId"] = new SelectList(_majorService.Get(), "Id", "Name");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _studentServices.Update(Student);
            return RedirectToPage("./Index");
        }
    }
}