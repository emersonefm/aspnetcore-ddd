using Aplicacao.Models;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;
        protected IHttpContextAccessor _httpContext;

        public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor httpContext)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
            _httpContext = httpContext;
        }

        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    _httpContext.HttpContext.Session.Clear();
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            ViewData["ErroLogin"] = "";

            if (ModelState.IsValid)
            {
                
                var senha = Criptografia.GetMd5Hash(loginViewModel.Senha);
                int usuario = _servicoAplicacaoUsuario.ValidarLogin(loginViewModel.Email, senha);

                if (usuario != 0)
                {
                    UsuarioViewModel usuarioRecuperado = _servicoAplicacaoUsuario.CarregarRegistro(usuario);

                    _httpContext.HttpContext.Session.SetString(Sessao.Nome_Usuario, usuarioRecuperado.Nome);
                    _httpContext.HttpContext.Session.SetString(Sessao.Email_Usuario, usuarioRecuperado.Email);
                    _httpContext.HttpContext.Session.SetInt32(Sessao.Codigo_Usuario, (int)usuarioRecuperado.Codigo);
                    _httpContext.HttpContext.Session.SetInt32(Sessao.Logado, 1);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErroLogin"] = "Email ou Senha inválidos";

                    return View(loginViewModel);
                }
            }
            else
            {
                return View(loginViewModel);
            }
        }
    }
}