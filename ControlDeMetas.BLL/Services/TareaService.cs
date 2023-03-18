using ControlDeMetas.DAL.Contracts;
using ControlDeMetas.Shared.Entities;
using ControlDeMetas.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeMetas.BLL.Services
{
    public class TareaService : BaseService<Tarea>
    {
        private readonly IRepository<Tarea> _tareaRepository;

        public TareaService(IRepository<Tarea> tareaRepository)
            : base(tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task<IEnumerable<Tarea>> GetTareasByEstatusAsync(EstatusTarea estatusTarea)
        {
            return await _tareaRepository.ListAsync(p => p.Estatus == estatusTarea);
        }

        public async Task<IEnumerable<Tarea>> SearchTareasAsync(string searchTerm)
        {
            return await _tareaRepository.ListAsync(p =>
                p.Nombre.Contains(searchTerm) );
        }
    }
}
