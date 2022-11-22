using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("pessoas_schema.pessoatelefone");
            builder.HasKey(x => x.IdPessoa);
            builder.Property(x => x.IdTelefone).HasColumnName("ID_TELEFONE");
        }
    }
}
