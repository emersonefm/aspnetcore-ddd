using Dominio.DTO;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos 
    {
        IEnumerable<GraficoDTO> ListaGrafico();
    }
}
