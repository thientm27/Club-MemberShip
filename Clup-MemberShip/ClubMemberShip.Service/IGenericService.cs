using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service;

public interface IGenericService<TEntity> where TEntity : BaseEntity
{
    public List<TEntity>? GetAll();
    public TEntity? GetById(object id);
    public Result Update(TEntity newEntity);
    public Result Delete(object idToDelete);
    public Result Add(TEntity newEntity);
}