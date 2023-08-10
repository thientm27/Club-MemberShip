using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMemberShip.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;
using ClubMemberShip.Repo.Repository;

namespace ClubMemberShip.Present.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IStudentServices _context;

        public RegisterModel(IStudentServices context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GradeId"] = new SelectList(_context.GetGrades(), "Id", "GradeYear");
            ViewData["MajorId"] = new SelectList(_context.GetMajors(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            var result = _context.Register(Student);

            // switch (result)
            // {
            //     case Result.Null:
            //         break;
            //     case Result.Ok:
            //         break;
            //     case Result.DuplicatedId:
            //         break;
            //     case Result.Fail:
            //         break;
            // }

            return Page();
        }
    }
}
