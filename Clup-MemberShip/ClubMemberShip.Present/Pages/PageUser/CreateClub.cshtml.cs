using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class CreateClubModel : PageModel
    {
        private readonly IClubServices _clubServices;
        private readonly IStudentServices _studentServices;

        public CreateClubModel(IClubServices clubServices, IStudentServices studentServices)
        {
            _clubServices = clubServices;
            _studentServices = studentServices;
        }

        public IActionResult OnGet()
        {
            var id = HttpContext.Session.GetString("User");
            Authentication(id);

            return Page();
        }

        [BindProperty] public Club Club { get; set; } = default!;
        public Student StudentLogin { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clubServices.StudentCreateClub(Club, StudentLogin.Id);
            return RedirectToPage("./Index");
        }

        public IActionResult Authentication(string? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Login");
            }

            var studentLogin = _studentServices.GetById(id);
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }

            StudentLogin = studentLogin;
            return Page();
        }
    }
}