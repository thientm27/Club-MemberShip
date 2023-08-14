using System.Linq.Expressions;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Repo;

public interface IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    List<TEntity> Get(params Expression<Func<TEntity, object>>[] includes);

    public List<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    public void Create(TEntity entity);
    public void CreateAutoId(TEntity entity);
    public TEntity? GetById(object? id);
    public void Update(TEntity entity);
    public void Delete(object? id);
    public void SaveChanges();
    Pagination<TEntity> ToPagination(int pageNumber = 0, int pageSize = 10, params Expression<Func<TEntity, object>>[] includes);
    Pagination<TEntity> ToPagination(IEnumerable<TEntity> list,int pageNumber = 0, int pageSize = 10, params Expression<Func<TEntity, object>>[] includes);

}