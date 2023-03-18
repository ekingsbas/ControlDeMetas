using ControlDeMetas.DAL.Abstract;
using ControlDeMetas.DAL.Contracts;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL.Repositories
{
    public class MetaRepository: Repository<Meta>, IRepository<Meta>
    {
        public MetaRepository(MetasDbContext dbContext) : base(dbContext)
        {
        }

        // Métodos específicos del repositorio de metas
    }
}
