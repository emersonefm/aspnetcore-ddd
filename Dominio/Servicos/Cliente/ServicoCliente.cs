using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        IRepositorioCliente _repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public void Cadastrar(Cliente cliente)
        {
            _repositorioCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return _repositorioCliente.Read(id);
        }

        public void Excluir(int id)
        {
            _repositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> Listagem()
        {
            return _repositorioCliente.Read();
        }
    }
}
