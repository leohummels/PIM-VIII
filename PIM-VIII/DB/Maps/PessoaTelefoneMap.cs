using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("pessoas_schema.pessoa_telefone");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id_Pessoa).HasColumnName("ID_TELEFONE");
            builder.Property(x => x.Id_Telefone).HasColumnName("ID_TELEFONE");
        }
    }
}
