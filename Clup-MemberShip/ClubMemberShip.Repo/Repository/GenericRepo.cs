using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Repo.Repository
{
    public class GenericRepo<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public IQueryable<TEntity> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            using var context = new ClubMembershipContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new ClubMembershipContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }


}
