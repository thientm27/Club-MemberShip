using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Service;

public interface IMemberRoleService : IGenericService<MemberRole>
{
    public void AddMultipleMember(int clubId, int clubBoardId, List<int> studentId);
    public List<Student> GetAllMemberOfBoard(int boardId);
}