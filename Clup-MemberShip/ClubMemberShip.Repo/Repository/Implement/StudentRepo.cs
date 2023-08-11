using ClubMemberShip.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShip.Repo.Repository.Implement;

public class StudentRepo : GenericRepo<Student>, IStudentRepo
{
    public StudentRepo(ClubMembershipContext context) : base(context)
    {
    }
}