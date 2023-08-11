using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminGrade
{
    public class IndexModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public IndexModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        
        public IList<Grade> Grade { get; set; } = default!;

        public void OnGetAsync()
        {
            Grade = _gradeService.GetAll();
        }
    }
}