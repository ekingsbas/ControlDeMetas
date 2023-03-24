using ControlDeMetas.DAL.Contracts;
using System.Linq.Expressions;

namespace ControlDeMetas.BLL.Contracts
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IRepository<TEntity> Repository { get; }
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
