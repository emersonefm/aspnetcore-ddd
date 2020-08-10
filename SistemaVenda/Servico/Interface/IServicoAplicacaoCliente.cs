using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IServicoAplicacaoCliente
    {
        void Cadastrar(ClienteViewModel clienteViewModel);
        void Excluir(int id);
        ClienteViewModel CarregarRegistro(int id);
        IEnumerable<ClienteViewModel> Listagem();
        IEnumerable<SelectListItem> ListaClienteCombo();
    }
}
