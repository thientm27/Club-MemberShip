using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class GradeService : GenericService<Grade>, IGradeService
{
    public GradeService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }


    public override List<Grade> GetAll()
    {
        return UnitOfWork.GradeRepo.Get().ToList();
    }

    public override Grade? GetById(object id)
    {
        return UnitOfWork.GradeRepo.GetById(id);
    }

    public override Result Update(Grade newEntity)
    {
        UnitOfWork.GradeRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.GradeRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Grade newEntity)
    {
        UnitOfWork.GradeRepo.Create(newEntity);
        return Result.Ok;
    }
}