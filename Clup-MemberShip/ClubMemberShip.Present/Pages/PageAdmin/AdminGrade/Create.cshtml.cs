using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminGrade
{
    public class CreateModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public CreateModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Grade Grade { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Grade == null)
            {
                return Page();
            }

            _gradeService.Add(Grade);
            return RedirectToPage("./Index");
        }
    }
}