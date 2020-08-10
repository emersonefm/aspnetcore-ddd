using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        new Venda Read(int id);
        new IEnumerable<Venda> Read();
        new void Delete(int id);
    }
}
