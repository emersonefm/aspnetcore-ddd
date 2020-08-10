using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(Repositorio.Contexto.ApplicationDbContext dbContext) : base(dbContext) { }

        public override IEnumerable<Produto> Read()
        {
            return _dbSet.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
