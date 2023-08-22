using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ClubActivityService : GenericService<ClubActivity>, IClubActivityService
{
    public ClubActivityService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<ClubActivity>? Get()
    {
        return UnitOfWork.ClubActivityRepo.Get(includeProperties: "").ToList();
    }

    public override Pagination<ClubActivity> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ClubActivityRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override ClubActivity? GetById(object? id)
    {
        return UnitOfWork.ClubActivityRepo.GetById(id);
    }

    public override Result Update(ClubActivity newEntity)
    {
        UnitOfWork.ClubActivityRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.ClubActivityRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(ClubActivity newEntity)
    {
        var maxId = (Get() ?? new List<ClubActivity>()).Max(o => o.Id);
        newEntity.Id = maxId + 1;
        newEntity.Status = Status.Active;

        UnitOfWork.ClubActivityRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public List<Student>? GetListStudentInActivity(int id)
    {
        var listJoin = UnitOfWork.ParticipantRepo.Get(filter: o => o.ClubActivityId == id);

        var listMemberShipId = listJoin.Select(o => o.MembershipId);
        var listMemberShip = UnitOfWork.MemberShipRepo.Get(filter: o => listMemberShipId.Contains(o.Id));

        var listStudentId = listMemberShip.Select(o => o.StudentId);

        return UnitOfWork.StudentRepo.Get(filter: o => listStudentId.Contains(o.Id));
    }
}