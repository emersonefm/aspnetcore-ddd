using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class ProdutoController : Controller
    {
        readonly IServicoAplicacaoProduto _servicoAplicacaoProduto;
        readonly IServicoAplicacaoCategoria _servicoAplicacaoCategoria;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            _servicoAplicacaoProduto = servicoAplicacaoProduto;
            _servicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoProduto.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            if (id != null)
            {
                viewModel = _servicoAplicacaoProduto.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = _servicoAplicacaoCategoria.ListaCategoriaCombo();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoProduto.Cadastrar(viewModel);
            }
            else
            {
                viewModel.ListaCategorias = _servicoAplicacaoCategoria.ListaCategoriaCombo();
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _servicoAplicacaoProduto.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}