
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PizzariaSys.AcessoDados.Mapping;
using PizzariaSys.Dominio;


namespace PizzariaSys.AcessoDados.Contexto
{
    public class EfContexto: DbContext
    {
        public EfContexto()
            :base("strConexao")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x=>x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x=>x.HasMaxLength(50));

            modelBuilder.Configurations.Add(new ClienteMap());
        }
    }
}
