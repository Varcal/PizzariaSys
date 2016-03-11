
using System.Web.Mvc;
using PizzariaSys.App.Interfaces;
using PizzariaSys.App.ViewModels;

namespace PizzariaSys.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppServico;

        public ClienteController(IClienteAppService clienteAppServicos)
        {
            _clienteAppServico = clienteAppServicos;
        }


        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _clienteAppServico.ListarTodos();
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
         

            _clienteAppServico.Inserir(model);
            

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
            var clienteViewModel = _clienteAppServico.ListarClienteTelefone(telefone);

            if (clienteViewModel == null)
            {
                return View();
            }

            return View("Detalhes", clienteViewModel);
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var clienteViewModel = _clienteAppServico.BuscarId(id);
            return View(clienteViewModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var clienteViewModel = _clienteAppServico.BuscarId(id);
            return View(clienteViewModel);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _clienteAppServico.Alterar(model);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var clienteViewModel = _clienteAppServico.BuscarId(id);

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            
            _clienteAppServico.Deletar(id);
            
            return RedirectToAction("Index");
        }
    }
}