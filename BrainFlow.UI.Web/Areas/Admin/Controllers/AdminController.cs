using BrainFlow.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrainFlow.UI.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region Conexoes
        private readonly IAfiliadoService _afiliadoService;
        #endregion

        #region Construtor
        public AdminController(IAfiliadoService afiliadoService)
        {
            _afiliadoService = afiliadoService;
        }
        #endregion

        #region Metodos

        #region AprovarAfiliados
        [HttpGet]
        public async Task<IActionResult> AprovarAfiliados()
        {
            var afiliadosPendentes = await _afiliadoService.BuscarAfiliadosPendentes();
            return View(afiliadosPendentes);
        }
        #endregion

        #region Aprovar
        [HttpPost]
        public async Task<IActionResult> Aprovar(int id)
        {
            var sucesso = await _afiliadoService.AprovarAfiliado(id);

            if (sucesso)
            {
                TempData["Modal-Sucesso"] = "Afiliado aprovado com sucesso.";
            }
            else
            {
                TempData["Modal-Erro"] = "Erro ao aprovar afiliado.";
            }

            return RedirectToAction("AprovarAfiliados");
        }
        #endregion

        #endregion
    }
}
