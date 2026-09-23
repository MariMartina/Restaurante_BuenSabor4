using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuenSabor.Restaurante.EntidadesDeNegocio;

namespace BuenSabor.Restaurante.UI.webAPPMVC.Controllers
{
    [Authorize]
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            var usuario = new Usuario();
            usuario.Correo = User.Identity?.Name ?? "Usuario";
            return View(usuario);
        }
    }
}