using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ClubActivityService : GenericService<ClubActivity>, IClubActivityService
{
    public ClubActivityService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<ClubActivity> Get()
    {
        throw new NotImplementedException();
    }

    public override Pagination<ClubActivity> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ClubActivityRepo.ToPagination(listEntities, pageIndex, pageSize);
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