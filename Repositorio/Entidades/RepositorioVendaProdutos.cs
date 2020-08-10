using Dominio.DTO;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : IRepositorioVendaProdutos
    {
        protected ApplicationDbContext _mContext;
        public RepositorioVendaProdutos(ApplicationDbContext mContext)
        {
            _mContext = mContext;
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            var lista = _mContext.VendaProdutos.Include(y => y.Produto).ToList().GroupBy(x => x.CodigoProduto).
                        Select(y => new GraficoDTO
                        {
                            CodigoProduto = y.FirstOrDefault().CodigoProduto,
                            Descricao = y.FirstOrDefault().Produto.Descricao,
                            TotalVendido = y.Sum(z => z.Quantidade)
                        }).ToList();

            return lista;
        }
    }
}
