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
}