using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMemberShip.Repo;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service
{
    public interface IStudentServices
    {
        public List<Student>? GetStudents();
        public List<Major>? GetMajors();
        public List<Grade>? GetGrades();
        public Student? GetStudent(string id);
        public Result UpdateStudent(Student student);
        public Result DeleteStudent(string id );
        public Result Register(Student student);
        public int Login(string id );
    }
}
