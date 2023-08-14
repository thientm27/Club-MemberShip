using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class ClubService : GenericService<Club>, IClubServices
{
    public ClubService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Club> GetAll()
    {
        return UnitOfWork.ClubRepo.Get().ToList();
    }

    public override Club GetById(object id)
    {
        throw new NotImplementedException();
    }

    public override Result Update(Club newEntity)
    {
        throw new NotImplementedException();
    }

    public override Result Delete(object idToDelete)
    {
        throw new NotImplementedException();
    }

    public override Result Add(Club newEntity)
    {
        throw new NotImplementedException();
    }
}