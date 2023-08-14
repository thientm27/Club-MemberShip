using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class GradeRepo : GenericRepo<Grade>, IGradeRepo
{
    public GradeRepo(ClubMembershipContext context) : base(context)
    {
    }
}