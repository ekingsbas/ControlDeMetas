using ControlDeMetas.DAL.Abstract;
using ControlDeMetas.DAL.Contracts;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL.Repositories
{
    public class TareaRepository : Repository<Tarea>, IRepository<Tarea>
    {
        public TareaRepository(MetasDbContext dbContext) : base(dbContext)
        {
        }

        // Métodos específicos del repositorio de Tareas
    }
}
