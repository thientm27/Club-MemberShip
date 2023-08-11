using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class MajorRepo : GenericRepo<Major>, IMajorRepo 
{
    public MajorRepo(ClubMembershipContext context) : base(context)
    {
    }
}