using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubMemberShip.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public RegisterModel(IStudentServices context, IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public IActionResult OnGet()
        {
            ViewData["GradeId"] = new SelectList(_studentServices.GetGrades(), "Id", "GradeYear");
            ViewData["MajorId"] = new SelectList(_studentServices.GetMajors(), "Id", "Name");
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
                    return RedirectToPage("/Login");
                case Result.DuplicatedId:
                    ModelState.AddModelError("Student.Code", "Student code is duplicated");
                    return OnGet();
            }

            return RedirectToPage("/Login");
        }
    }
}