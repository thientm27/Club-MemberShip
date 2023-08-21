using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageUser
{
    public class ClubDetailModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        private readonly IClubServices _clubServices;
        [BindProperty(SupportsGet = true)] public int PageIndex1 { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages1;

        public ClubDetailModel(IStudentServices studentServices, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        public IList<Student> Student { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return Redirect("./Index");
            }
            var data = _clubServices.GetStudentInClub(PageIndex1 - 1, PageSize, (int)id); // take student in list
            TotalPages1 = data.TotalPagesCount;
            Student = data.Items.ToList();

            
            return Page();
        }
    }
}