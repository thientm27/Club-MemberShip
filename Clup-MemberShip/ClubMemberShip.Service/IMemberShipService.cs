using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Service;

public interface IMemberShipService : IGenericService<Membership>
{
    public Membership? GetById(int clubId, int studentId);
}