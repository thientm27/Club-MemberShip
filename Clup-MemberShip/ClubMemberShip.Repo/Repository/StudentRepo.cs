using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class StudentRepo : GenericRepo<Student>, IStudentRepo
{
    public StudentRepo(ClubMembershipContext context) : base(context)
    {
    }

    public Student? GetByStudentCode(string id)
    {
        return Get(filter: student => student.Code.ToLower().Equals(id.ToLower())).FirstOrDefault();
    }
}