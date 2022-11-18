using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoas_schema.pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("NOME");
            builder.Property(x => x.Cpf).HasColumnName("CPF");
            builder.HasOne(x => x.Endereco).WithMany();
        }
    }
}
