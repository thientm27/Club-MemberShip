using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminStudent
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public DetailsModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public Student Student { get; set; } = default!;

        public  IActionResult OnGet(int? id)
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
    }
}