using ClubMemberShip.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemberShip.Repo.Repository
{
    public class StudentRepo
    {
        public List<Student> GetAllStudents()
        
        {
         var _context = new ClubMembershipContext();
            return _context.Students
                .Include(s => s.Grade)
                .Include(s => s.Major).ToList();
        }
    }
}
