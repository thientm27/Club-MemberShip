using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service.Service;
using ClubMemberShip.Service;

namespace ClubMemberShip.Present.Pages.Students
{
    public class EditModel : PageModel
    {

        private IStudentServices _studentServices = new ClubMemberShipService();
        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {

            var student = _studentServices.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;

            ViewData["GradeId"] = new SelectList(_studentServices.GetGrades(), "Id", "GradeYear");
            ViewData["MajorId"] = new SelectList(_studentServices.GetMajors(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _studentServices.UpdateStudent(Student);

            return RedirectToPage("./Index");
        }

    }
}
