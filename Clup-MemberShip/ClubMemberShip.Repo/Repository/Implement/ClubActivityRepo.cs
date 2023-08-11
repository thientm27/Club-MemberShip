using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class ClubActivityRepo : GenericRepo<ClubActivity>, IClubActivityRepo
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }

    public ClubActivityRepo(ClubMembershipContext context) : base(context)
    {
    }
}