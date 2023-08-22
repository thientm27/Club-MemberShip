using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service
{
    public interface IStudentServices : IGenericService<Student>
    {
        public List<Major>? GetMajors();
        public List<Grade>? GetGrades();
        public Student? GetStudentById(int id);
        public List<Student> GetClubOfStudent(int id);
        public Membership? GetMemberShipById(int id);
        public Membership? GetMemberShipByClubIdAndStudentId(int studentId, int clubId);
        public bool CheckRegisterToClub(int studentId, int clubId);
        public Membership? RegisterToClub(Membership membership, bool save = true);
        public Pagination<Student> GetPaginationIgnoreId(int pageIndex, int pageSize, List<int> listIgnore);
        public Result Register(Student student);
        public int Login(string id );
    }
}
