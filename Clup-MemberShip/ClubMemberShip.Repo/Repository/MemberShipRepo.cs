using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class MemberShipRepo : GenericRepo<Membership>, IMemberShipRepo
{
    public MemberShipRepo(ClubMembershipContext context) : base(context)
    {
    }
}