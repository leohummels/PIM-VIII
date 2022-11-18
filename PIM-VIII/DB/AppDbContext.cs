using Microsoft.EntityFrameworkCore;
using PIM_VIII.Models;

namespace PIM_VIII.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<Endereco> Endereco { get; set;}
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Endereco)
                .WithOne();
            modelBuilder.Entity<Pessoa>()
                .Navigation(p => p.Endereco)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.TipoTelefone)
                .WithMany();
            modelBuilder.Entity<Telefone>()
                 .Navigation(p => p.TipoTelefone)
                 .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
