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
    public interface IStudentServices : IGenericService<Student>
    {
        public List<Major>? GetMajors();
        public List<Grade>? GetGrades();
        public Result Register(Student student);
        public int Login(string id );
    }
}
