using System.Linq.Expressions;

namespace ClubMemberShip.Repo.Repository;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
    public List<TEntity> GetAll(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");
    public void Create(TEntity entity);
    public TEntity? GetById(object? id);
    public void Update(TEntity entity);
}