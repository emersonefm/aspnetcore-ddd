using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(Repositorio.Contexto.ApplicationDbContext dbContext) : base(dbContext) { }

        public override Venda Read(int id)
        {
            return _dbSet.Where(x => x.Codigo == id).Include(x => x.Produtos).ThenInclude(y => y.Produto).AsNoTracking().FirstOrDefault();
        }

        public override IEnumerable<Venda> Read()
        {
            return _dbSet.Include(x => x.Cliente).AsNoTracking().ToList();
        }

        public override void Delete(int id)
        {
            //antes precisamos excluir os id´s de venda que estão na tabela venda produto

            var listaProdutos = _dbSet.Include(x => x.Produtos).Where(y => y.Codigo == id).
                                AsNoTracking().ToList();

            foreach (var item in listaProdutos[0].Produtos)
            {
                VendaProdutos vendaProduto = new VendaProdutos
                {
                    CodigoVenda = id,
                    CodigoProduto = item.CodigoProduto
                };

                //Adiciona uma entidade ao contexto manualmente.
                DbSet<VendaProdutos> dbSetAux;
                dbSetAux = _db.Set<VendaProdutos>();
                dbSetAux.Remove(vendaProduto);
            }

            base.Delete(id);
        }       
    }
}
