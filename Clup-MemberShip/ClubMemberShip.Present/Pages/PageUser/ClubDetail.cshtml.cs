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
        public int PageSize1 { get; set; } = 3;
        public int TotalPages1;

        [BindProperty(SupportsGet = true)] public int PageIndex2 { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize2 { get; set; } = 3;
        public int TotalPages2;

        public ClubDetailModel(IStudentServices studentServices, IClubServices clubServices)
        {
            _studentServices = studentServices;
            _clubServices = clubServices;
        }

        public IList<Student> Student { get; set; } = default!;
        public IList<ClubActivity> ClubActivity { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return Redirect("./Index");
            }

            var data = _clubServices.GetStudentInClub(PageIndex1 - 1, PageSize1, (int)id); // take student in club
            TotalPages1 = data.TotalPagesCount;
            Student = data.Items.ToList();


            var data2 = _clubServices.GetActivityInClub(PageIndex2 - 1, PageSize2, (int)id); // take event in club
            TotalPages2 = data2.TotalPagesCount;
            ClubActivity = data2.Items.ToList();
            return Page();
        }
    }
}