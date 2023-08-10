using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository.Interface;

public interface IStudentRepo
{
    public Student? GetStudent(string id);
    public void DeleteStudent(string id);

}