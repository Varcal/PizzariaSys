
using System.Linq;
using PizzariaSys.AcessoDados.Contexto;
using PizzariaSys.AcessoDados.Repositorios.Core;
using PizzariaSys.Dominio.Entidades;
using PizzariaSys.Dominio.Interfaces.Repositorios;


namespace PizzariaSys.AcessoDados.Repositorios
{


    public class ClienteRepositorio: RepositorioBase<Cliente>, IClienteRepositorio
    {

        public ClienteRepositorio(EfContexto db)
            :base(db)
        {
            _db = db;
        }


        public Cliente BuscarClientePorTelefone(string numeroTelefone)
        {
            return _db.Clientes.FirstOrDefault(x=>x.Telefone == numeroTelefone);
        }
      
    }
}
