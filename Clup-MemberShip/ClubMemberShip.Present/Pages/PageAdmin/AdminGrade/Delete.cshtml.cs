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
    public class DeleteModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public DeleteModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        [BindProperty] public Grade Grade { get; set; } = default!;

        public  IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade =  _gradeService.GetById(id);

            if (grade == null)
            {
                return NotFound();
            }
            else
            {
                Grade = grade;
            }

            return Page();
        }

        public  IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = _gradeService.GetById(id);

            if (grade != null)
            {
                Grade = grade;
                _gradeService.Delete(id);
  
            }

            return RedirectToPage("./Index");
        }
    }
}