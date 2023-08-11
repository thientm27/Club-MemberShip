using System.Linq.Expressions;

namespace ClubMemberShip.Repo.Repository;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    public IQueryable<TEntity> GetAll();

    public IEnumerable<TEntity> GetAll(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");
    public void Create(TEntity entity);
    public TEntity? GetById(object? id);
    public void Update(TEntity entity);
}