using ClubMemberShip.Repo.Models;
using Microsoft.EntityFrameworkCore;
namespace ClubMemberShip.Repo.Repository
{
    public class StudentRepo
    {
        public List<Student>? GetAllStudents(){
              var _context = new ClubMembershipContext();
            return _context.Students
                .Include(s => s.Grade)
                .Include(s => s.Major).ToList();
        }

        public Student? GetStudent(string id)
        {
            var _context = new ClubMembershipContext();
            return _context.Students.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Set status to 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStudent(string id)
        {
            var _context = new ClubMembershipContext();
            Student? std = _context.Students.FirstOrDefault(o => o.Id == id);
      

            if (std != null)
            {
                std.Status = 0;
                _context.Attach(std).State = EntityState.Modified;
                _context.SaveChanges();
                return 0;
            }
            else
            {
                return -1;
            }
         
        }

        public int UpdateStudent(Student student)
        {
            if (student == null)
            {
                return -1;
            }
            var _context = new ClubMembershipContext();
            _context.Attach(student).State = EntityState.Modified;
            _context.SaveChanges();
            return 0;
        }

        public int AddStudent(Student student)
        {
            var _context = new ClubMembershipContext();
            if (_context.Students == null || student == null)
            {
                return -1;
            }
            Student? std = _context.Students.FirstOrDefault(o => o.Id == student.Id);
            if (std != null)
            {
                return 1;
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            return 0;
        }


        // 1  Duplicatated id
        // 0  OK
        // -1 Null
    }
}
