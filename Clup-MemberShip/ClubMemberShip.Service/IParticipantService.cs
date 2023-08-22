using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Service;

public interface IParticipantService  : IGenericService<Participant>
{
    public List<Participant>? GetByCluActivityId(int clubActivityId);
}