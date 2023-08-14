using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class ClubActivityRepo : GenericRepo<ClubActivity>, IClubActivityRepo
{
    public ClubActivityRepo(ClubMembershipContext context) : base(context)
    {
    }
}