using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class ParticipantRepo : GenericRepo<Participant>, IParticipantRepo
{
    public ParticipantRepo(ClubMembershipContext context) : base(context)
    {
    }
}