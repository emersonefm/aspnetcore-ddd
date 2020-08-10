using Aplicacao.Servico.Interface;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria _servicoCategoria;

        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoriaViewModel)
        {
            Categoria categoria = new Categoria()
            {
                Codigo = categoriaViewModel.Codigo,
                Descricao = categoriaViewModel.Descricao
            };

            _servicoCategoria.Cadastrar(categoria);
        }

        public CategoriaViewModel CarregarRegistro(int id)
        {
            var registro = _servicoCategoria.CarregarRegistro(id);
            CategoriaViewModel categoriaViewModel = new CategoriaViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return categoriaViewModel;
        }

        public void Excluir(int id)
        {
            _servicoCategoria.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriaCombo()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            retorno = this.Listagem().Select(x => new SelectListItem
            {
                Value = x.Codigo.ToString(),
                Text = x.Descricao
            }).ToList();

            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            return _servicoCategoria.Listagem().Select(y => new CategoriaViewModel
            {
                Codigo = y.Codigo,
                Descricao = y.Descricao
            }).ToList();
        }
    }
}
