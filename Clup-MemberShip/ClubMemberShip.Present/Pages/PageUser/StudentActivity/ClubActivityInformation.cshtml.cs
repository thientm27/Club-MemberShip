﻿using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubMemberShip.Web.Pages.PageUser.StudentActivity
{
    public class ClubActivityInformationModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IStudentServices _studentServices;
        public ClubActivity ClubActivity { get; set; } = default!;
        public IList<Student> Student { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public int PageIndex3 { get; set; } = 1;
        public int PageSize3 { get; set; } = 3;
        public int TotalPages3;

        public bool JoinAble { get; set; } = true;

        public ClubActivityInformationModel(IClubActivityService clubActivityService, IStudentServices studentServices)
        {
            _clubActivityService = clubActivityService;
            _studentServices = studentServices;
        }

        public IActionResult OnGetAsync(int? id)
        {
            var studentLogin = _studentServices.GetById(HttpContext.Session.GetString("User"));
            if (studentLogin == null)
            {
                return RedirectToPage("/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var clubActivity = _clubActivityService.GetById((int)id);
            if (clubActivity == null)
            {
                return NotFound();
            }

            ClubActivity = clubActivity;

            var participants = _clubActivityService.GetListStudentInActivity((int)id);
            Student = participants ?? new List<Student>();

            foreach (var oStudent in Student)
            {
                if (oStudent.Id == studentLogin.Id)
                {
                    JoinAble = false;
                }
            }
            
            return Page();
        }
    }
}