using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository.Interface;

namespace ClubMemberShip.Repo.Repository;

public class GradeRepo : GenericRepo<Grade>, IGradeRepo
{
    public override void Delete(object? id)
    {
        throw new NotImplementedException();
    }
}