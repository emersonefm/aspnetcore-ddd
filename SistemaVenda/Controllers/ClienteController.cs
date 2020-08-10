using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {
        readonly IServicoAplicacaoCliente _servicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            _servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoCliente.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();
            if (id != null)
            {
                viewModel = _servicoAplicacaoCliente.CarregarRegistro((int)id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoCliente.Cadastrar(viewModel);
            }
            else
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _servicoAplicacaoCliente.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}