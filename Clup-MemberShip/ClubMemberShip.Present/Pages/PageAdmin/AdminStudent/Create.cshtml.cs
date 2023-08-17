using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;

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

            var result = _studentServices.Add(Student);

            switch (result)
            {
                case Result.Ok:
                    return RedirectToPage("./Index");
                case Result.DuplicatedId:
                    ModelState.AddModelError("Student.Code", "Student code is duplicated");
                    return OnGet();
            }

            return RedirectToPage("./Index");
        }
    }
}