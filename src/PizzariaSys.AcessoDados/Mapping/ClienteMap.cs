
using System.Data.Entity.ModelConfiguration;
using PizzariaSys.Dominio.Entidades;

namespace PizzariaSys.AcessoDados.Mapping
{
    public class ClienteMap: EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
            Property(x => x.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
            Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.Bairro)
               .HasColumnName("Bairro")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
            Property(x => x.Telefone)
              .HasColumnName("Telefone")
              .HasColumnType("char")
              .HasMaxLength(10)
              .IsRequired();
        }
    }
}
