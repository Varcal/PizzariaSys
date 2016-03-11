using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzariaSys.App.ViewModels;
using PizzariaSys.Dominio.Entidades;

namespace PizzariaSys.App.Interfaces
{
    public interface IClienteAppService
    {

        void Inserir(ClienteViewModel model);
        void Alterar(ClienteViewModel model);
        void Deletar(int id);
        ClienteViewModel BuscarId(int id);
        IEnumerable<ClienteViewModel> ListarTodos();
        void Commit();

        ClienteViewModel ListarClienteTelefone(string numeroTelefone);
    }
}
