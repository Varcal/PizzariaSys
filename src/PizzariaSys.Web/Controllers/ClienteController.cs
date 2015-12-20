using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PizzariaSys.Dominio;
using PizzariaSys.Dominio.Entidades;
using PizzariaSys.Dominio.Interfaces;
using PizzariaSys.Dominio.Interfaces.Servicos;
using PizzariaSys.Dominio.Servicos;
using PizzariaSys.Web.ViewModels;
using Action = Antlr.Runtime.Misc.Action;

namespace PizzariaSys.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicos _clienteServicos;

        public ClienteController(IClienteServicos clienteServicos)
        {
            _clienteServicos = clienteServicos;
        }


        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _clienteServicos.ListarTodos();
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cliente = new Cliente
            {
                Nome = model.Nome,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                Bairro = model.Bairro,
                Telefone = model.Telefone
            };

            _clienteServicos.Inserir(cliente);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConsultaTelefone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultaTelefone(string telefone)
        {
            var cliente = _clienteServicos.ListarClienteTelefone(telefone);

            if (cliente == null)
            {
                return View();
            }

            return View("Detalhes", new ClienteViewModel(cliente));
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var cliente = _clienteServicos.BuscarId(id);
            return View(new ClienteViewModel(cliente));
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var cliente = _clienteServicos.BuscarId(id);
            return View(new ClienteViewModel(cliente));
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var cliente = _clienteServicos.BuscarId(id);
            return View(new ClienteViewModel(cliente));
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var cliente = _clienteServicos.BuscarId(id);
            _clienteServicos.Deletar(cliente);
            return RedirectToAction("Index");
        }
    }
}