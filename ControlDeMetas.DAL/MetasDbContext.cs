using ControlDeMetas.DAL.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Agregar configuraciones de entidades
            modelBuilder.ApplyConfiguration(new MetaConfiguration());
            modelBuilder.ApplyConfiguration(new TareaConfiguration());
        }

        public DbSet<Meta> Meta { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
    }
}
