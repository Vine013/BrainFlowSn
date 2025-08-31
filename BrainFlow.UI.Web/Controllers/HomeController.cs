using BrainFlow.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrainFlow.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
