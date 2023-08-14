using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ClubService : GenericService<Club>, IClubServices
{
    public ClubService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Club> Get()
    {
        return UnitOfWork.ClubRepo.Get().ToList();
    }

    public override Pagination<Club> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);
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