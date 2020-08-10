using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Cadastrar(Usuario usuario)
        {
            _repositorioUsuario.Create(usuario);
        }

        public Usuario CarregarRegistro(int id)
        {
            return _repositorioUsuario.Read(id);
        }

        public void Excluir(int id)
        {
            _repositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> Listagem()
        {
            return _repositorioUsuario.Read();
        }

        public int ValidarLogin(string email, string senha)
        {
            return _repositorioUsuario.ValidarLogin(email, senha);
        }
    }
}
