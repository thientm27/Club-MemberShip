using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service;

public interface IClubServices : IGenericService<Club>
{
    public Pagination<Student> GetStudentInClub(int pageIndex, int pageSize, int clubId);
    public Pagination<ClubActivity> GetActivityInClub(int pageIndex, int pageSize, int clubId);
    public Club? StudentCreateClub(Club newClub, int studentId,out string  message); // also create new board and join
    public ClubBoard? CreateClubBoard(ClubBoard newClubBoard, bool save = true); // also create new board and join
    public Membership? JoinClub(Membership membership, bool save = true);
    public MemberRole? JoinClubBoard(MemberRole memberRole, bool save = true);
    public Result? LeaveClub(Membership memberRole, bool save = true);
    public Pagination<Club>? GetJoinedClub(int pageIndex, int pageSize, int studentId);
    public List<Club>? GetJoinedClub(int studentId);
    public Pagination<Club> GetAvailableClub(int pageIndex, int pageSize, int studentId);
}