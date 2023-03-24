using ControlDeMetas.Shared.Entities;

namespace ControlDeMetas.Client.Contracts
{
    public interface IMetaClientService
    {
        Task<List<Meta>> GetAll();
        Task<Meta> GetById(long id);
        Task Add(Meta meta);
        Task Update(long id, Meta meta);
        Task Delete(long id);

    }
}
