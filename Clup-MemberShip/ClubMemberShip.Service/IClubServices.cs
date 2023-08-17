using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service;

public interface IClubServices : IGenericService<Club>
{
    public Club? StudentCreateClub(Club newClub, int studentId); // also create new board and join
    public ClubBoard? CreateClubBoard(ClubBoard newClubBoard); // also create new board and join
    public Membership? JoinClub(Membership membership);
    public MemberRole? JoinClubBoard(MemberRole memberRole);
    public Result? LeaveClub(MemberRole memberRole);
}