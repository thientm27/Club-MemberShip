using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class GradeService : GenericService<Grade>, IGradeService
{
    public GradeService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }


    public override List<Grade> Get()
    {
        return UnitOfWork.GradeRepo.Get().ToList();
    }

    public override Pagination<Grade> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.GradeRepo.ToPagination(listEntities, pageIndex, pageSize);
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
        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;
        
        UnitOfWork.GradeRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }
}