using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzariaSys.App.Interfaces;
using PizzariaSys.App.ViewModels;
using PizzariaSys.Dominio.Entidades;
using PizzariaSys.Dominio.Interfaces.Servicos;

namespace PizzariaSys.App.Servicos
{
    public class ClienteAppServico: IClienteAppService
    {

        private readonly IClienteServicos _clienteServicos;

        public ClienteAppServico(IClienteServicos clienteServicos)
        {
            _clienteServicos = clienteServicos;
        }


        public void Inserir(ClienteViewModel model)
        {

            var cliente = new Cliente
            {
                Id = model.Id,
                Nome = model.Nome,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                Bairro = model.Bairro,
                Telefone = model.Telefone
            };


            _clienteServicos.Inserir(cliente);
            _clienteServicos.Commit();
        }

        public void Alterar(ClienteViewModel model)
        {

            var cliente = new Cliente
            {
                Id = model.Id,
                Nome = model.Nome,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                Bairro = model.Bairro,
                Telefone = model.Telefone
            };

            _clienteServicos.Alterar(cliente);
            _clienteServicos.Commit();
        }

        public void Deletar(int id)
        {

            var cliente = _clienteServicos.BuscarId(id);

            _clienteServicos.Deletar(cliente);
            _clienteServicos.Commit();
        }

        public ClienteViewModel BuscarId(int id)
        {
            var cliente = _clienteServicos.BuscarId(id);


            var clienteViewModel = new ClienteViewModel(cliente);

            return clienteViewModel;
        }

        public IEnumerable<ClienteViewModel> ListarTodos()
        {
            var clientes = _clienteServicos.ListarTodos();

            IList<ClienteViewModel> clienteViewModelList = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                var clienteViewModel = new ClienteViewModel(cliente);
                clienteViewModelList.Add(clienteViewModel);
            }

            return clienteViewModelList;
        }

        public void Commit()
        {
            _clienteServicos.Commit();
        }

        public ClienteViewModel ListarClienteTelefone(string numeroTelefone)
        {
            var cliente = _clienteServicos.ListarClienteTelefone(numeroTelefone);

            var clienteViewModel = new ClienteViewModel(cliente);

            return clienteViewModel;
        }
    }
}
