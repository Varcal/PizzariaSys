using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzariaSys.Dominio.Interfaces;
using PizzariaSys.Dominio.Repositorios;

namespace PizzariaSys.Dominio.Negocios
{
    public class ClienteNegocios: ClienteRepositorio, IClienteNegocios
    {
        public Cliente ListarClienteTelefone(string param)
        {
            var cliente = ListarTodos().FirstOrDefault(x => x.Telefone == param);

            return cliente;
        }
    }
}
