using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class MemberRoleService : GenericService<MemberRole>, IMemberRoleService
{
    public MemberRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<MemberRole>? Get()
    {
        throw new NotImplementedException();
    }

    public override Pagination<MemberRole> GetPagination(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }

    public override MemberRole? GetById(object? id)
    {
        throw new NotImplementedException();
    }

    public override Result Update(MemberRole newEntity)
    {
        throw new NotImplementedException();
    }

    public override Result Delete(object idToDelete)
    {
        throw new NotImplementedException();
    }

    public override Result Add(MemberRole newEntity)
    {
        throw new NotImplementedException();
    }

    public void AddMultipleMember(int clubId, int clubBoardId, List<int> studentId)
    {
        var membership =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && studentId.Contains(o.StudentId));

        foreach (var o in membership)
        {
            var existed = UnitOfWork.MemberRoleRepo.GetIgnoreDeleted(filter: p =>
                p.MembershipId == o.Id && p.ClubBoardId == clubBoardId);

            if (existed.Count > 0)
            {
                existed[0].Status = Status.Active;
            }
            else
            {
                UnitOfWork.MemberRoleRepo.Create(new MemberRole
                {
                    MembershipId = o.Id,
                    ClubBoardId = clubBoardId,
                    StartDay = DateTime.Today,
                    EndDay = default,
                    Role = null,
                });
            }
        }

        UnitOfWork.SaveChange();
    }

    public void RemoveMultipleMember(int clubId, int clubBoardId, List<int> studentId)
    {
        var membership =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && studentId.Contains(o.StudentId));

        foreach (var o in membership)
        {
            var existed = UnitOfWork.MemberRoleRepo.GetIgnoreDeleted(filter: p =>
                p.MembershipId == o.Id && p.ClubBoardId == clubBoardId);

            if (existed.Count > 0)
            {
                existed[0].Status = Status.Deleted;
            }
        }
        UnitOfWork.SaveChange();
    }

    public List<Student> GetAllMemberOfBoard(int clubId)
    {
        var memberRole = UnitOfWork.MemberRoleRepo.Get(filter: o => o.ClubBoardId == clubId);
        var listId = memberRole.Select(o => o.MembershipId);

        var membership =
            UnitOfWork.MemberShipRepo.Get(filter: o => listId.Contains(o.Id));

        var listStudentId = membership.Select(o => o.StudentId);
        return UnitOfWork.StudentRepo.Get(filter: o => listStudentId.Contains(o.Id), includeProperties: "Grade,Major");
    }

    public Pagination<Student> GetPaginationAllMemberOfBoard(int pageIndex, int pageSize, int boardId)
    {
        var listEntities = GetAllMemberOfBoard(boardId);
        return UnitOfWork.StudentRepo.ToPagination(listEntities, pageIndex, pageSize);
    }
}