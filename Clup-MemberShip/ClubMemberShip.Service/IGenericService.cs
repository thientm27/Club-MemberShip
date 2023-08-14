using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.Service;

public interface IGenericService<TEntity> where TEntity : BaseEntity
{
    public List<TEntity>? Get();
    public Pagination<TEntity> GetPagination(int pageIndex, int pageSize);
    public TEntity? GetById(object id);
    public Result Update(TEntity newEntity);
    public Result Delete(object idToDelete);
    public Result Add(TEntity newEntity);
}