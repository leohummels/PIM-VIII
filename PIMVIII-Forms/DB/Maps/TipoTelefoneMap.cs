using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class TipoTelefoneMap : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("pessoas_schema.telefone_tipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo);
        }
    }
}
