using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class MajorService : GenericService<Major>, IMajorService
{
    public MajorService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Major> Get()
    {
        return UnitOfWork.MajorRepo.Get().ToList();
    }

    public override Pagination<Major> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.MajorRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override Major? GetById(object id)
    {
        return UnitOfWork.MajorRepo.GetById(id);
    }

    public override Result Update(Major newEntity)
    {
        UnitOfWork.MajorRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.MajorRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Major newEntity)
    {
        UnitOfWork.MajorRepo.Create(newEntity);
        return Result.Ok;
    }
}