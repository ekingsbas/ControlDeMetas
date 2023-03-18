using ControlDeMetas.DAL.Abstract;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeTareas.DAL.Repositories
{
    public class TareaRepository : Repository<Tarea>
    {
        public TareaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        // Métodos específicos del repositorio de Tareas
    }
}
