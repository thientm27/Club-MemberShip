using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
{
    protected readonly IUnitOfWork UnitOfWork;

    protected GenericService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    
    public abstract List<TEntity> GetAll();
    public abstract TEntity GetById(object id);
    public abstract Result Update(TEntity newEntity);
    public abstract Result Delete(object idToDelete);
    public abstract Result Add(TEntity newEntity);
}

public enum Result
{
    Ok,
    Null,
    DuplicatedId,
    NullParameter,
    NullProperties,
}