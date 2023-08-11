using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Implement;

public class ClubRepo : GenericRepo<Club>, IClubRepo
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }
}