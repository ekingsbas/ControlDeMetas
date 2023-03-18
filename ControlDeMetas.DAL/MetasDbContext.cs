using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL
{
    public class MetasDbContext: DbContext
    {
        public MetasDbContext(DbContextOptions<MetasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meta> Clientes { get; set; }
        public DbSet<Tarea> Productos { get; set; }
    }
}
