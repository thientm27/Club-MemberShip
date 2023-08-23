using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Service;

public interface IClubBoardService : IGenericService<ClubBoard>
{
    public List<ClubBoard> GetByClubId(int clubId);
}