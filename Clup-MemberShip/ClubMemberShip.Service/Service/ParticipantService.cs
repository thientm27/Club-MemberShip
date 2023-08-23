using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ParticipantService : GenericService<Participant>, IParticipantService
{
    public ParticipantService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Participant>? Get()
    {
        return UnitOfWork.ParticipantRepo.Get().ToList();
    }

    public override Pagination<Participant> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ParticipantRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override Participant? GetById(object? id)
    {
        return UnitOfWork.ParticipantRepo.GetById(id);
    }

    public override Result Update(Participant newEntity)
    {
        UnitOfWork.ParticipantRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.ParticipantRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Participant newEntity)
    {
        var isExisted = UnitOfWork.ParticipantRepo.Get(filter: mj =>
            mj.MembershipId == newEntity.MembershipId && mj.ClubActivityId == newEntity.ClubActivityId);
        if (isExisted.Count > 0)
        {
            return Result.DuplicatedId;
        }

        UnitOfWork.ParticipantRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public List<Participant>? GetByCluActivityId(int clubActivityId)
    {
        return UnitOfWork.ParticipantRepo.Get(filter: o => o.ClubActivityId == clubActivityId);
    }

    public void AddMultipleMember(int clubId, int clubActivityId, List<int> studentId)
    {
        var membership =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && studentId.Contains(o.StudentId));

        foreach (var o in membership)
        {
            var existed = UnitOfWork.ParticipantRepo.GetIgnoreDeleted(filter: p =>
                p.MembershipId == o.Id && p.ClubActivityId == clubActivityId);
            if (existed.Count > 0)
            {
                existed[0].Status = Status.Active;
            }
            else
            {
                UnitOfWork.ParticipantRepo.Create(new Participant
                {
                    MembershipId = o.Id,
                    ClubActivityId = clubActivityId,
                    JoinDate = DateTime.Today,
                    LeaveDate = null,
                    RegisterDate = DateTime.Today,
                });
            }
        }

        UnitOfWork.SaveChange();
    }

    public void LeaveActivity(int clubId, int clubActivityId, int studentId)
    {
        var membership =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && studentId == o.StudentId);

        var activity =
            UnitOfWork.ParticipantRepo.Get(
                o => o.ClubActivityId == clubActivityId && o.MembershipId == membership[0].Id);

        var participant = activity[0];
        participant.Status = Status.Deleted;
        UnitOfWork.ParticipantRepo.Update(participant);
        UnitOfWork.SaveChange();
    }
}