using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class MajorRepo : GenericRepo<Major>, IMajorRepo 
{
    public override void Delete(object? id)
    {
        // throw new NotImplementedException();
    }

    public MajorRepo(ClubMembershipContext context) : base(context)
    {
    }
}