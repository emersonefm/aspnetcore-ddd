using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IServicoAplicacaoUsuario
    {
        void Cadastrar(UsuarioViewModel usuarioViewModel);
        void Excluir(int id);
        UsuarioViewModel CarregarRegistro(int id);
        int ValidarLogin(string email, string senha);
    }
}
