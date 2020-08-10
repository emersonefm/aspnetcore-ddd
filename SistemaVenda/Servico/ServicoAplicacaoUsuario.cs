using Aplicacao.Models;
using Aplicacao.Servico.Interface;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoUsuario _servicoUsuario;

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public void Cadastrar(UsuarioViewModel usuarioViewModel)
        {           
            Usuario usuario = new Usuario()
            {
                Codigo = usuarioViewModel.Codigo,
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = usuarioViewModel.Senha
            };

            _servicoUsuario.Cadastrar(usuario);
        }

        public UsuarioViewModel CarregarRegistro(int id)
        {
            var registro = _servicoUsuario.CarregarRegistro(id);
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                Email = registro.Email,
                Senha = registro.Senha
            };

            return usuarioViewModel;
        }

        public void Excluir(int id)
        {
            _servicoUsuario.Excluir(id);
        }

        public int ValidarLogin(string email, string senha)
        {
            return _servicoUsuario.ValidarLogin(email, senha);
        }
    }
}
