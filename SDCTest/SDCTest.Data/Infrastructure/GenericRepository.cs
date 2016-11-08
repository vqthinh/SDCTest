using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PagedList;

namespace SDCTest.Data.Infrastructure
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private SDCTestDbContext context;
        private readonly IDbSet<TEntity> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected SDCTestDbContext DbContext
        {
            get { return context ?? (context = DbFactory.Init()); }
        }

        protected GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            this.dbSet = DbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IPagedList<TEntity> GetPaging(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy=null,int pageNumber = 5,int pageSize=10)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
                return orderBy(query).ToPagedList(pageNumber,pageSize);
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


    }
}
