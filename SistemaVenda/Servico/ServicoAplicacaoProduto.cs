using Aplicacao.Servico.Interface;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto _servicoProduto;

        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto()
            {
                Codigo = produtoViewModel.Codigo,
                Descricao = produtoViewModel.Descricao,
                Quantidade = produtoViewModel.Quantidade,
                Valor = (decimal)produtoViewModel.Valor,
                CodigoCategoria = (int)produtoViewModel.CodigoCategoria
            };

            _servicoProduto.Cadastrar(produto);
        }

        public ProdutoViewModel CarregarRegistro(int id)
        {
            var registro = _servicoProduto.CarregarRegistro(id);
            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria
            };

            return produtoViewModel;
        }

        public void Excluir(int id)
        {
            _servicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            return _servicoProduto.Listagem().Select(y => new ProdutoViewModel
            {
                Codigo = y.Codigo,
                Descricao = y.Descricao,
                Quantidade = y.Quantidade,
                Valor = (decimal)y.Valor,
                DescricaoCategoria = y.Categoria.Descricao,
                CodigoCategoria = (int)y.CodigoCategoria
            }).ToList();
        }

        public IEnumerable<SelectListItem> ListaProdutoCombo()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            retorno = this.Listagem().Select(x => new SelectListItem
            {
                Value = x.Codigo.ToString(),
                Text = x.Descricao
            }).ToList();

            return retorno;
        }
    }
}
