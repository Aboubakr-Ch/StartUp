using Domain.Entities;
using Infrastructure.Repository;
using Infrastructure;

namespace Application.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private AppDbContext context;

        private bool disposed;

        public UnitOfWork()
        {
            InitContext();
        }

        private void InitContext(AppDbContext contextParam = null)
        {
            if (context != null)
                context.Dispose();
            repositories.Clear();
            context = contextParam ?? new AppDbContext();
        }

        public static IUnitOfWork Instance()
        {
            return new UnitOfWork();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (!repositories.Keys.Contains(typeof(TEntity)))
            {
                repositories.Add(typeof(TEntity), new GenericRepository<TEntity>(context));
            }
            return repositories[typeof(TEntity)] as GenericRepository<TEntity>;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                InitContext();
                throw new Exception("Error", exception);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }
    }
}
