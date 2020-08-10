using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
        IRepositorioCategoria _repositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public void Cadastrar(Categoria categoria)
        {
            _repositorioCategoria.Create(categoria);
        }

        public Categoria CarregarRegistro(int id)
        {
            return _repositorioCategoria.Read(id);
        }

        public void Excluir(int id)
        {
            _repositorioCategoria.Delete(id);
        }

        public IEnumerable<Categoria> Listagem()
        {
            return _repositorioCategoria.Read();
        }
    }
}
