using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class ClubService : ClubMemberShipService, IClubServices
{
    public ClubService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}