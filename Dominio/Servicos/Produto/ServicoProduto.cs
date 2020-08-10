using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        IRepositorioProduto _repositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public void Cadastrar(Produto produto)
        {
            _repositorioProduto.Create(produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return _repositorioProduto.Read(id);
        }

        public void Excluir(int id)
        {
            _repositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> Listagem()
        {
            return _repositorioProduto.Read();
        }
    }
}
