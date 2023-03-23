using ControlDeMetas.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlDeMetas.DAL.Configurations
{
    public class MetaConfiguration : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nombre).IsRequired().HasMaxLength(80);
        }
    }
}
