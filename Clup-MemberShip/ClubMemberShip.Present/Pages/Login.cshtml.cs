using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubMemberShip.Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Id { get; set; }
        public string Msg { get; set; }

        private readonly IStudentServices _clubMemberShipService;

        public LoginModel(IStudentServices clubMemberShipService)
        {
            _clubMemberShipService = clubMemberShipService;
        }

        public IActionResult OnPostLogin()
        {
            if (!ModelState.IsValid)
            {
                Msg = "Please input your id";
                return Page();
            }

            var result = _clubMemberShipService.Login(Id);
            if (result == 1)
            {
                HttpContext.Session.SetString("User", Id);
                return RedirectToPage("./PageUser/Index");
            }

            if (result == -1)
            {
                HttpContext.Session.SetString("User", "Admin");
                return RedirectToPage("./PageAdmin/Index");
            }

            Msg = "You student code not found";
            HttpContext.Session.SetString("User", "None");
            return Page();
        }

        public void OnPostLogout()
        {
            HttpContext.Session.Clear();
        }

        public IActionResult OnPostRegister()
        {
            return RedirectToPage("./Register");
        }
    }
}