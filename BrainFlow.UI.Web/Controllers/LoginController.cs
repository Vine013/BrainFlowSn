using BrainFlow.Model;
using BrainFlow.Service;
using BrainFlow.Service.Interfaces;
using BrainFlow.UI.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrainFlow.UI.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        #region Repositorios e Serviços
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly IAfiliadoService _afiliadoService;
        #endregion

        #region Construtor
        public LoginController(IAutenticacaoService autenticacaoService, IAfiliadoService afiliadoService)
        {
            _autenticacaoService = autenticacaoService;
            _afiliadoService = afiliadoService;
        }
        #endregion

        #region Metodos

        #region EfetuarLogin
        [HttpGet]
        public IActionResult EfetuarLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EfetuarLogin(LoginViewMOD loginViewMOD, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                TempData["Modal-Erro"] = "Por favor, preencha todos os campos corretamente.";
                return View(loginViewMOD);
            }

            var login = new Login
            {
                Username = loginViewMOD.Username,
                Password = loginViewMOD.Password
            };

            var usuario = await _autenticacaoService.Login(login);

            if (usuario != null)
            {
                string role = usuario.CdTipoUsuario switch
                {
                    1 => "Admin",
                    2 => "Afiliado",
                    3 => "Comum",
                    _ => "Comum",
                };

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.CdUsuario.ToString()),
                        new Claim(ClaimTypes.Email, usuario.TxEmail),
                        new Claim(ClaimTypes.Name, usuario.NoUsuario),
                        new Claim(ClaimTypes.Role, role)
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    IssuedUtc = DateTime.Now,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Modal-Erro"] = "Usuário e/ou Senha Inválidos.";
            return View(loginViewMOD);
        }
        #endregion

        #region Sair
        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("EfetuarLogin");
        }
        #endregion

        #region Cadastrar
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioMOD usuario, string TxSenha)
        {
            var cdUsuario = await _autenticacaoService.CadastrarUsuarioComum(usuario, TxSenha);

            if (cdUsuario > 0)
            {
                TempData["Modal-Sucesso"] = "Cadastro realizado com sucesso! Faça login para continuar.";
                return RedirectToAction("EfetuarLogin", "Login");
            }

            TempData["Modal-Erro"] = "Erro ao realizar o cadastro. Por favor, tente novamente.";
            return View(usuario);
        }
        #endregion

        #region CadastrarAfiliado
        [HttpGet]
        public IActionResult CadastrarAfiliado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAfiliado(AfiliadoMOD afiliado)
        {
            if (ModelState.IsValid)
            {
                var cdAfiliado = await _afiliadoService.CadastrarAfiliado(afiliado);

                if (cdAfiliado > 0)
                {
                    TempData["Modal-Sucesso"] = "Solicitação de afiliação enviada com sucesso! Aguarde a aprovação do administrador.";
                    return RedirectToAction("EfetuarLogin", "Login");
                }
            }

            TempData["Modal-Erro"] = "Erro ao enviar a solicitação. Por favor, verifique os dados e tente novamente.";
            return View(afiliado);
        }
        #endregion

        #endregion
    }
}
