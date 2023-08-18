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

        [BindProperty] public Club Club { get; set; } = default!;
        public string Msg { get; set; }

        public CreateClubModel(IClubServices clubServices, IStudentServices studentServices)
        {
            _clubServices = clubServices;
            _studentServices = studentServices;
        }

        public void OnGet()
        {
            var id = HttpContext.Session.GetString("User");
            Authentication(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }
            var clubCreated = _clubServices.StudentCreateClub(Club, studentLogin.Id, out var messageString);
            if (clubCreated == null)
            {
                Msg = messageString;
                OnGet();
                return Page();
            }

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

            return null;
        }
    }
}