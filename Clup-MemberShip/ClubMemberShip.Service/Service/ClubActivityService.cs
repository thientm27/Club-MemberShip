using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class ClubActivityService : ClubMemberShipService, IClubActivityService
{
    public ClubActivityService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}