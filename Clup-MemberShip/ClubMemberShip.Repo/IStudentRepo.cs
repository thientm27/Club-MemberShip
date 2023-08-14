using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo;

public interface IStudentRepo :  IGenericRepository<Student>
{
    public Student? GetByStudentCode(string id);
}