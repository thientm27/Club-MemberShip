using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminStudent
{
    public class CreateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IGradeService _gradeService;
        private readonly IMajorService _majorService;

        public CreateModel(IStudentServices studentServices, IGradeService gradeService, IMajorService majorService)
        {
            _studentServices = studentServices;
            _gradeService = gradeService;
            _majorService = majorService;
        }


        public IActionResult OnGet()
        {
            ViewData["GradeId"] = new SelectList(_gradeService.Get(), "Id", "GradeYear");
            ViewData["MajorId"] = new SelectList(_majorService.Get(), "Id", "Name");
            return Page();
        }

        [BindProperty] public Student Student { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _studentServices.Add(Student);
            return RedirectToPage("./Index");
        }
    }
}