using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service;

public interface IMemberRoleService : IGenericService<MemberRole>
{
    public void AddMultipleMember(int clubId, int clubBoardId, List<int> studentId);
    public void RemoveMultipleMember(int clubId, int clubBoardId, List<int> studentId);
    public List<Student> GetAllMemberOfBoard(int boardId);
    public Pagination<Student> GetPaginationAllMemberOfBoard(int pageIndex, int pageSize, int boardId);
}