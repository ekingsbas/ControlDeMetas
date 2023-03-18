using ControlDeMetas.DAL.Contracts;

namespace ControlDeMetas.BLL.Contracts
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IRepository<TEntity> Repository { get; }
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
