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
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente _servicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente()
            {
                Codigo = clienteViewModel.Codigo,
                Nome = clienteViewModel.Nome,
                CNPJ_CPF = clienteViewModel.CNPJ_CPF,
                Celular = clienteViewModel.Celular,
                Email = clienteViewModel.Email                
            };

            _servicoCliente.Cadastrar(cliente);
        }

        public ClienteViewModel CarregarRegistro(int id)
        {
            var registro = _servicoCliente.CarregarRegistro(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Celular = registro.Celular,
                Email = registro.Email
            };

            return clienteViewModel;
        }

        public void Excluir(int id)
        {
            _servicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            return _servicoCliente.Listagem().Select(y => new ClienteViewModel
            {
                Codigo = y.Codigo,
                Nome = y.Nome,
                CNPJ_CPF = y.CNPJ_CPF,
                Celular = y.Celular,
                Email = y.Email                
            }).ToList();
        }

        public IEnumerable<SelectListItem> ListaClienteCombo()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            retorno = this.Listagem().Select(x => new SelectListItem
            {
                Value = x.Codigo.ToString(),
                Text = x.Nome
            }).ToList();

            return retorno;
        }
    }
}
