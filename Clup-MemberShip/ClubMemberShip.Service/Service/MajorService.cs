using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class MajorService : GenericService<Major>, IMajorService
{
    public MajorService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Major> GetAll()
    {
        return UnitOfWork.MajorRepo.Get().ToList();
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