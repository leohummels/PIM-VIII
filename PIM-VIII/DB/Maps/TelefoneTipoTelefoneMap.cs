using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models.Relations;

namespace PIM_VIII.DB.Maps
{
    public class TelefoneTipoTelefoneMap : IEntityTypeConfiguration<TelefoneTipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TelefoneTipoTelefone> builder)
        {
            builder.ToTable("pessoas_schema.relacao_telefone_tipo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id_Telefone).HasColumnName("id_telefone");
            builder.Property(x => x.Id_TipoTelefone).HasColumnName("id_tipo_telefone");
        }
    }
}
