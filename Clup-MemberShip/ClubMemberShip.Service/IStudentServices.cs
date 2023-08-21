using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service
{
    public interface IStudentServices : IGenericService<Student>
    {
        public List<Major>? GetMajors();
        public List<Grade>? GetGrades();
        public List<Student> GetClubOfStudent(int id);
        public Result Register(Student student);
        public int Login(string id );
    }
}
