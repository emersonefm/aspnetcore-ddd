using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoUsuario : IServicoCRUD<Usuario>
    {
        int ValidarLogin(string email, string senha);
    }
}
