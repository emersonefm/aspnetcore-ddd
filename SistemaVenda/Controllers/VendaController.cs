using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using System;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        readonly IServicoAplicacaoVenda _servicoAplicacaoVenda;
        readonly IServicoAplicacaoProduto _servicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente _servicoAplicacaoCliente;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda,
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            _servicoAplicacaoVenda = servicoAplicacaoVenda;
            _servicoAplicacaoProduto = servicoAplicacaoProduto;
            _servicoAplicacaoCliente = servicoAplicacaoCliente;

        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoVenda.Listagem());
        }


        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();

            if (id != null)
            {
                viewModel = _servicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            //var data = viewModel.Data;
            viewModel.ListaClientes = _servicoAplicacaoCliente.ListaClienteCombo();
            viewModel.ListaProdutos = _servicoAplicacaoProduto.ListaProdutoCombo();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Data = new DateTime(viewModel.Data.Value.Year, viewModel.Data.Value.Month, viewModel.Data.Value.Day,
                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                _servicoAplicacaoVenda.Cadastrar(viewModel);
            }
            else
            {
                viewModel.ListaClientes = _servicoAplicacaoCliente.ListaClienteCombo();
                viewModel.ListaProdutos = _servicoAplicacaoProduto.ListaProdutoCombo();
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _servicoAplicacaoVenda.Excluir(id);
            return RedirectToAction("Index");
        }

        public decimal LerValorProduto(int id)
        {
            return (decimal)_servicoAplicacaoProduto.CarregarRegistro(id).Valor;
        }

        public ActionResult ListarProdutos(int id)
        {
            try
            {
                var venda = _servicoAplicacaoVenda.CarregarRegistro(id);
                return Json(new { success = true, produtos = venda.Produtos });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message });
            }
        }
    }
}