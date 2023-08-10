using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository.Interface;

namespace ClubMemberShip.Repo.Repository;

public class ClubRepo : GenericRepo<Club>, IClubRepo
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }
}