using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClubMemberShip.Present.Pages.Students
{
    public class IndexModel : PageModel
    {
        private IStudentServices _studentServices = new ClubMemberShipService();
        public IList<Student> Student { get; set; } = default!;

        public void OnGet()
        {
            Student = _studentServices.GetStudents() ?? new List<Student>();
        }
    }
}
