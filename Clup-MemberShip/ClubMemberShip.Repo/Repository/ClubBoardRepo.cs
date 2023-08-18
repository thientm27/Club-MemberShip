using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository;

public class ClubBoardRepo : GenericRepo<ClubBoard>, IClubBoardRepo
{
    public ClubBoardRepo(ClubMembershipContext context) : base(context)
    {
    }
}