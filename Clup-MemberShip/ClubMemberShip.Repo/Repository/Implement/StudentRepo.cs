using ClubMemberShip.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShip.Repo.Repository.Implement;

public class StudentRepo : GenericRepo<Student>, IStudentRepo
{
    public StudentRepo(ClubMembershipContext context) : base(context)
    {
    }

    public Student? GetByStudentCode(string id)
    {
        return GetAll(filter: student => student.Code.ToLower().Equals(id.ToLower())).FirstOrDefault();
    }
}