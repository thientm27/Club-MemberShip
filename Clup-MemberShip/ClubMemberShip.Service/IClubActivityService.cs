using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Service;

public interface IClubActivityService : IGenericService<ClubActivity>
{
    public List<Student>? GetListStudentInActivity(int id);
    public ClubActivity? AddWithResult(ClubActivity newEntity);
}