using Dominio.Repositorio;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(Repositorio.Contexto.ApplicationDbContext dbContext) : base(dbContext) { }

        public int ValidarLogin(string email, string senha)
        {
            var usuario = _dbSet.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            return (usuario == null) ? 0 : usuario.Codigo;
        }
    }
}
