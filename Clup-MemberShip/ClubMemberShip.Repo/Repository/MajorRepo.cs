using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository.Interface;

namespace ClubMemberShip.Repo.Repository;

public class MajorRepo : GenericRepo<Major>, IMajorRepo 
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }
}