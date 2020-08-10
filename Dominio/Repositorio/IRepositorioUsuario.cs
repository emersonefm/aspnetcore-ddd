using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {       
        int ValidarLogin(string email, string senha);
    }
}
