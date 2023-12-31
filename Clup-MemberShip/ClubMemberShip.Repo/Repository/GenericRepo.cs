﻿using System.Linq.Expressions;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShip.Repo.Repository;

public class GenericRepo<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ClubMembershipContext Context;

    public GenericRepo(ClubMembershipContext context)
    {
        this.Context = context;
    }


    public List<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }

        return query.Where(x => x.Status != Status.Deleted).ToList();
    }

    public TEntity? GetById(object? id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public List<TEntity> GetIgnoreDeleted(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }

        return query.ToList();
    }

   

    public TEntity Create(TEntity entity)
    {
        entity.Status = Status.Active;
        return Context.Set<TEntity>().Add(entity).Entity;
    }

    public void Update(TEntity entityToUpdate)
    {
        Context.Set<TEntity>().Attach(entityToUpdate);
        Context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public void Delete(object? id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            entity.Status = Status.Deleted;
            Update(entity);
        }
    }

    public Pagination<TEntity> ToPagination(IEnumerable<TEntity> list, int pageIndex = 0, int pageSize = 10,
        params Expression<Func<TEntity, object>>[] includes)
    {
        if (list is IQueryable<TEntity> query)
        {
            list = includes.Aggregate(query, (entity, property) => entity.Include(property));
        }

        var result = new Pagination<TEntity>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = list.Where(c => c.Status != Status.Deleted).Skip(pageIndex * pageSize).Take(pageSize).ToList(),
            TotalItemsCount = list.Where(c => c.Status != Status.Deleted).Count()
        };

        return result;
    }
}