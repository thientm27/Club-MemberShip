namespace ClubMemberShip.Repo;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    public IQueryable<TEntity> GetAll();
    public void Create(TEntity entity);
    public void Update(TEntity entity);
}