using System.Linq.Expressions;
using ClubMemberShip.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShip.Repo.Repository.Implement;

public abstract class GenericRepo<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    public IEnumerable<TEntity> GetAll(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        using var context = new ClubMembershipContext();
        IQueryable<TEntity> query = context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }

        return query.ToList();
    }

    public TEntity? GetById(object? id)
    {
        using var context = new ClubMembershipContext();
        return context.Set<TEntity>().Find(id);
    }

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
        
    public void Update(TEntity entityToUpdate)
    {
        using var context = new ClubMembershipContext();
        context.Set<TEntity>().Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public abstract void Delete(object? id);
}