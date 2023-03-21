using ControlDeMetas.Shared.Entities;

namespace ControlDeMetas.Client.Contracts
{
    public interface IMetaClientService
    {
        Task<List<Meta>> GetAll();
        Task<Meta> GetById(int id);
        Task Add(Meta meta);
        Task Update(int id, Meta meta);
        Task Delete(int id);

    }
}
