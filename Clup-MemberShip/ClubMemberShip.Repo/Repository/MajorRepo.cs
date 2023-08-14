using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class MajorRepo : GenericRepo<Major>, IMajorRepo 
{
    public MajorRepo(ClubMembershipContext context) : base(context)
    {
    }
}