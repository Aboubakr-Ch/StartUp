using Domain.Entities;
using Infrastructure.Repository;

namespace Application.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        void Save();
    }
}
