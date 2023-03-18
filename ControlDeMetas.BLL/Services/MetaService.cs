using ControlDeMetas.DAL.Contracts;
using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeMetas.BLL.Services
{
    public class MetaService: BaseService<Meta>
    {
        private readonly IRepository<Meta> _metaRepository;

        public MetaService(IRepository<Meta> metaRepository)
            : base(metaRepository)
        {
            _metaRepository = metaRepository;
        }

        
        public async Task<IEnumerable<Meta>> SearchMetasAsync(string searchTerm)
        {
            return await _metaRepository.ListAsync(p =>
                p.Nombre.Contains(searchTerm) );
        }
    }
}
