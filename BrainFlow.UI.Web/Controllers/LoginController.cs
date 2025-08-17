using BrainFlow.Model;
using BrainFlow.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BrainFlow.UI.Web.Models;

namespace BrainFlow.UI.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        #region Repositorios e Serviços
        private readonly IAutenticacaoService _autenticacaoService;
        #endregion

        #region Construtor
        public LoginController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
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
            if (ModelState.IsValid)
            {
                var login = new Login
                {
                    Username = loginViewMOD.Username,
                    Password = loginViewMOD.Password
                };
                var usuario = await _autenticacaoService.Login(login);

                if (usuario != null)
                {
                    string role = string.Empty;
                    switch (usuario.CdTipoUsuario)
                    {
                        case 1:
                            role = "Admin";
                            break;
                        case 2:
                            role = "Comum";
                            break;
                        case 3:
                            role = "Afiliado";
                            break;
                        default:
                            role = "Comum";
                            break;
                    }

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

                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos.");
            }
            return View(loginViewMOD);
        }
        #endregion

        #region Sair
        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("EfetuarLogin");
        }
        #endregion

        #endregion
    }
}
