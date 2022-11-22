using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM_VIII.Models;

namespace PIM_VIII.DB.Maps
{
    public class EnderecoMap : Endereco, IEntityTypeConfiguration<Endereco> 
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("pessoas_schema.endereco");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro);
            builder.Property(x => x.Bairro);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Cep);
            builder.Property(x => x.Estado);
        }
    }
}
