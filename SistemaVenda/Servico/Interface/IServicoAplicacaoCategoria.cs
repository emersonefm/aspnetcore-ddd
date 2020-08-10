using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IServicoAplicacaoCategoria
    {
        void Cadastrar(CategoriaViewModel categoriaViewModel);
        void Excluir(int id);
        CategoriaViewModel CarregarRegistro(int id);
        IEnumerable<CategoriaViewModel> Listagem();
        IEnumerable<SelectListItem> ListaCategoriaCombo();
    }
}
