using ControlDeMetas.DAL.Abstract;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL.Repositories
{
    public class MetaRepository: Repository<Meta>
    {
        public MetaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        // Métodos específicos del repositorio de metas
    }
}
