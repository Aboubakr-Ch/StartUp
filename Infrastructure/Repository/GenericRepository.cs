using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private AppDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null,
                                          int skip = -1, int take = -1, bool asNoTracking = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Length > 0)
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            query = orderBy != null ? orderBy(query) : query.OrderBy(x => x.Id);

            if (skip != -1)
            {
                query = query.Skip(skip);
            }

            if (take != -1)
            {
                query = query.Take(take);
            }

            if (asNoTracking) query.AsNoTracking();

            return query;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null,
                                  int skip = -1, int take = -1, bool asNoTracking = false)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take, asNoTracking).ToList();
        }
        public T GetById(int id, string[] includeProperties = null)
        {
            return GetQueryable(item => item.Id == id, includeProperties: includeProperties).FirstOrDefault();
        }
        public int Count(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return GetQueryable(filter, orderBy).Count();
        }
        public T Add(T entity)
        {
            if (entity.GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                entity.CreationDate = DateTime.Now;
                entity.ModificationDate = null;
            }
            return context.Set<T>().Add(entity).Entity;
        }
        public void Update(T entity)
        {
            if (entity.GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                entity.ModificationDate = DateTime.Now; ;
            }
            context.Set<T>().Update(entity);
        }
        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
    }
}
