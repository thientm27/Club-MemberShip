using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminStudent
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public DeleteModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
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
            else
            {
                Student = student;
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentServices.GetById(id);
            if (student != null)
            {
                Student = student;
                _studentServices.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}