using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.DTO;

namespace Dominio.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        IRepositorioVenda _repositorioVenda;
        IRepositorioVendaProdutos _repositorioVendasProdutos;

        public ServicoVenda(IRepositorioVenda repositorioVenda, IRepositorioVendaProdutos repositorioVendasProdutos)
        {
            _repositorioVenda = repositorioVenda;
            _repositorioVendasProdutos = repositorioVendasProdutos;
        }

        public void Cadastrar(Venda venda)
        {
            _repositorioVenda.Create(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return _repositorioVenda.Read(id);
        }

        public void Excluir(int id)
        {
            _repositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {
            return _repositorioVenda.Read();
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            return _repositorioVendasProdutos.ListaGrafico();
        }
    }
}
