using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class MemberShipService : GenericService<Membership>, IMemberShipService
{
    public MemberShipService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Membership>? Get()
    {
        return UnitOfWork.MemberShipRepo.Get().ToList();
    }

    public override Pagination<Membership> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.MemberShipRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override Membership? GetById(object? id)
    {
        return UnitOfWork.MemberShipRepo.GetById(id);
    }

    public override Result Update(Membership newEntity)
    {
        UnitOfWork.MemberShipRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.MemberShipRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Membership newEntity)
    {
        var isExisted = UnitOfWork.MemberShipRepo.Get(filter: mj =>
            mj.ClubId == newEntity.ClubId && mj.StudentId == newEntity.StudentId && mj.Status != Status.Deleted);
        if (isExisted.Count > 0)
        {
            return Result.DuplicatedId;
        }

        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;

        UnitOfWork.MemberShipRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public Membership? GetById(int clubId, int studentId)
    {
        var result = UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && o.StudentId == studentId, includeProperties: "Club,Student");
        if (result.Count > 0)
        {
            return result[0];
        }

        return null;
    }
}