using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public interface IStudentRepo :  IGenericRepository<Student>
{
    public Student? GetByStudentCode(string id);
}