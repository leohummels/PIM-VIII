using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("pessoas_schema.telefone");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).HasColumnName("NUMERO");
            builder.Property(x => x.DDD).HasColumnName("DDD");
            builder.Property(x => x.TipoTelefone).HasColumnName("tipo");
        }
    }
}
