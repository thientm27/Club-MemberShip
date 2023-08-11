using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class ClubActivityService : GenericService<ClubActivity>, IClubActivityService
{
    public ClubActivityService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<ClubActivity> GetAll()
    {
        throw new NotImplementedException();
    }

    public override ClubActivity GetById(object id)
    {
        throw new NotImplementedException();
    }

    public override Result Update(ClubActivity newEntity)
    {
        throw new NotImplementedException();
    }

    public override Result Delete(object idToDelete)
    {
        throw new NotImplementedException();
    }

    public override Result Add(ClubActivity newEntity)
    {
        throw new NotImplementedException();
    }
}