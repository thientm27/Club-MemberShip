using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
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

    public override Club? GetById(object id)
    {
        return UnitOfWork.ClubRepo.GetById(id);
    }

    public override Result Update(Club newEntity)
    {
        UnitOfWork.ClubRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.ClubRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Club newEntity)
    {
        var isExisted = UnitOfWork.ClubRepo.Get(filter: club => club.Code == newEntity.Code);
        if (isExisted.Count > 0)
        {
            return Result.DuplicatedId;
        }

        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;
        newEntity.Status = Status.Active;
        
        UnitOfWork.ClubRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }
}