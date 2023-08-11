using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubMemberShip.Present.Pages
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

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            var result = _clubMemberShipService.Login(Id);
            if (result == 1)
            {
                Msg = "Hi user";
                return Page();
            }

            if (result == -1)
            {
                // admin
                Msg = "Hi admin";
                return RedirectToPage("./PageAdmin/Index");
            }

            Msg = "Id not available";
            return Page();
        }
        public IActionResult OnPostRegister()
        {
            return RedirectToPage("./Register");
        }
    }
}