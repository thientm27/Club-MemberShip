using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ClubBoardService : GenericService<ClubBoard>, IClubBoardService
{
    public ClubBoardService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<ClubBoard>? Get()
    {
        return UnitOfWork.ClubBoardRepo.Get().ToList();
    }

    public override Pagination<ClubBoard> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ClubBoardRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override ClubBoard? GetById(object? id)
    {
        return UnitOfWork.ClubBoardRepo.GetById(id);
    }

    public override Result Update(ClubBoard newEntity)
    {
        UnitOfWork.ClubBoardRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.ClubBoardRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(ClubBoard newEntity)
    {
        var maxId = UnitOfWork.ClubBoardRepo.GetIgnoreDeleted().Max(o => o.Id);
        newEntity.Id = maxId + 1;
        newEntity.Status = Status.Active;

        UnitOfWork.ClubBoardRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public List<ClubBoard> GetByClubId(int clubId)
    {
        return UnitOfWork.ClubBoardRepo.Get(filter: o => o.ClubId == clubId, includeProperties: "Club");
    }
}