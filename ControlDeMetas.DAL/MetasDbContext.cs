using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL
{
    public class MetasDbContext: DbContext
    {
        private readonly string _connectionString;

        public MetasDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MetasDbContext(DbContextOptions<MetasDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Meta> Clientes { get; set; }
        public DbSet<Tarea> Productos { get; set; }
    }
}
