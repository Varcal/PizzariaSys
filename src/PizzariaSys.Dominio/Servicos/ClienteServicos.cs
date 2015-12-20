﻿

using System.Linq;
using PizzariaSys.Dominio.Entidades;
using PizzariaSys.Dominio.Interfaces.Repositorios;
using PizzariaSys.Dominio.Interfaces.Servicos;
using PizzariaSys.Dominio.Servicos.Core;

namespace PizzariaSys.Dominio.Servicos
{
    public class ClienteServicos: ServicosBase<Cliente>, IClienteServicos
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServicos(IClienteRepositorio clienteRepositorio)
            :base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente ListarClienteTelefone(string param)
        {
            var cliente = _clienteRepositorio.ListarTodos().FirstOrDefault(x => x.Telefone == param);

            return cliente;
        }
    }
}
