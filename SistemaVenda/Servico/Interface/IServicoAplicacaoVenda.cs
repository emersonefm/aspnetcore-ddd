using Dominio.DTO;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
        void Cadastrar(VendaViewModel vendaViewModel);
        void Excluir(int id);
        VendaViewModel CarregarRegistro(int id);
        IEnumerable<VendaViewModel> Listagem();
    }
}
