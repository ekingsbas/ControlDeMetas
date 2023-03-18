using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL.Configurations
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(t => t.IdMeta).IsRequired();
            builder.HasOne(t => t.Meta).WithMany(m => m.Tareas).HasForeignKey(t => t.IdMeta);
        }
    }
}
