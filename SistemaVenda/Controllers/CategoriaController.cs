using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        readonly IServicoAplicacaoCategoria _servicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            _servicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoCategoria.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                viewModel = _servicoAplicacaoCategoria.CarregarRegistro((int)id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoCategoria.Cadastrar(viewModel);
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
            _servicoAplicacaoCategoria.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}