using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null,
                           int skip = -1, int take = -1, bool asNoTracking = false);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null,
                                   int skip = -1, int take = -1, bool asNoTracking = false);
        T GetById(int id, string[] includeProperties = null);
        int Count(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
