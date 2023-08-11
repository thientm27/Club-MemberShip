using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class GradeRepo : GenericRepo<Grade>, IGradeRepo
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }

    public GradeRepo(ClubMembershipContext context) : base(context)
    {
    }
}