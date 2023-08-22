using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class MemberShipService : GenericService<Major>, IMemberShipService
{
   

    public MemberShipService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Major>? Get()
    {
        throw new NotImplementedException();
    }

    Pagination<Membership> IGenericService<Membership>.GetPagination(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }

    Membership? IGenericService<Membership>.GetById(object? id)
    {
        throw new NotImplementedException();
    }

    public Result Update(Membership newEntity)
    {
        throw new NotImplementedException();
    }

    List<Membership>? IGenericService<Membership>.Get()
    {
        throw new NotImplementedException();
    }

    public override Pagination<Major> GetPagination(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }

    public override Major? GetById(object? id)
    {
        throw new NotImplementedException();
    }

    public override Result Update(Major newEntity)
    {
        throw new NotImplementedException();
    }

    public override Result Delete(object idToDelete)
    {
        throw new NotImplementedException();
    }

    public Result Add(Membership newEntity)
    {
        throw new NotImplementedException();
    }

    public override Result Add(Major newEntity)
    {
        throw new NotImplementedException();
    }
}