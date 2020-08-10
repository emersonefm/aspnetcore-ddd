using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IServicoAplicacaoProduto
    {
        void Cadastrar(ProdutoViewModel produtoViewModel);
        void Excluir(int id);
        ProdutoViewModel CarregarRegistro(int id);
        IEnumerable<ProdutoViewModel> Listagem();
        IEnumerable<SelectListItem> ListaProdutoCombo();
    }
}
