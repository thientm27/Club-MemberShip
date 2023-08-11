using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class ClubRepo : GenericRepo<Club>, IClubRepo
{
    public ClubRepo(ClubMembershipContext context) : base(context)
    {
    }
}