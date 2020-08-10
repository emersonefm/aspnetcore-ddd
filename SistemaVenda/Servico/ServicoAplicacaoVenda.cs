using Aplicacao.Models;
using Aplicacao.Servico.Interface;
using Dominio.DTO;
using Dominio.Interfaces;
using Newtonsoft.Json;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda _servicoVenda;

        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            _servicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel vendaViewModel)
        {
            Venda venda = new Venda()
            {
                Codigo = vendaViewModel.Codigo,
                Data = (DateTime)vendaViewModel.Data,
                CodigoCliente = (int)vendaViewModel.CodigoCliente,
                Total = vendaViewModel.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(vendaViewModel.JsonProdutos)
            };

            _servicoVenda.Cadastrar(venda);
        }

        public VendaViewModel CarregarRegistro(int id)
        {
            var registro = _servicoVenda.CarregarRegistro(id);
            VendaViewModel clienteViewModel = new VendaViewModel()
            {
                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Produtos = registro.Produtos.Select(x => new VendaProdutoViewModel
                {
                    CodigoVenda = id,
                    CodigoProduto = x.CodigoProduto,
                    Quantidade = x.Quantidade,
                    ValorTotal = x.ValorTotal,
                    NomeProduto = x.Produto.Descricao,
                    ValorUnitario = x.ValorUnitario
                }).ToList(),
                Total = registro.Total
            };

            return clienteViewModel;
        }

        public void Excluir(int id)
        {
            _servicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            return _servicoVenda.Listagem().Select(y => new VendaViewModel
            {
                Codigo = y.Codigo,
                Data = (DateTime)y.Data,
                CodigoCliente = (int)y.CodigoCliente,
                NomeCliente = y.Cliente.Nome,
                Total = y.Total
            }).ToList();
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            return _servicoVenda.ListaGrafico().Select(x => new GraficoViewModel
            {
                CodigoProduto = x.CodigoProduto,
                Descricao = x.Descricao,
                TotalVendido = x.TotalVendido
            }).ToList();
        }
    }
}
