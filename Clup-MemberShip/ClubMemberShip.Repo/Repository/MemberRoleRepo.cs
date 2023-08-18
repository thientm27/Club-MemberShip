using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class MemberRoleRepo: GenericRepo<MemberRole>, IMemberRoleRepo
{
    public MemberRoleRepo(ClubMembershipContext context) : base(context)
    {
    }
}