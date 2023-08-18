using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service;

public interface IClubServices : IGenericService<Club>
{
    public Club? StudentCreateClub(Club newClub, int studentId); // also create new board and join
    public ClubBoard? CreateClubBoard(ClubBoard newClubBoard); // also create new board and join
    public Membership? JoinClub(Membership membership);
    public MemberRole? JoinClubBoard(MemberRole memberRole);
    public Result? LeaveClub(Membership memberRole);
    public Pagination<Club> GetJoinedClub(int pageIndex, int pageSize, int studentId);
    public Pagination<Club> GetAvailableClub(int pageIndex, int pageSize, int studentId);
}