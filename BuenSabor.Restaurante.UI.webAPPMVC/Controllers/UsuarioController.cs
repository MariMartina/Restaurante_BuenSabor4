using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuenSabor.Restaurante.EntidadesDeNegocio;
using BuenSabor.Restaurante.LogicaDeNegocios;

namespace BuenSabor.Restaurante.UI.webAPPMVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Inicio");
            ViewBag.Primero = !UsuarioBL.HayUsuarios();
            return View(new Usuario());
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Correo,Clave")] Usuario pUsuario)
        {
            ViewBag.Primero = !UsuarioBL.HayUsuarios();
            if (!ModelState.IsValid) return View(pUsuario);

            var usuario = UsuarioBL.IniciarSesion(pUsuario);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Correo o contraseña incorrecta");
                return View(pUsuario);
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, usuario.Correo) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties { IsPersistent = false });

            return RedirectToAction("Index", "Inicio");
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Registro()
        {
            bool primero = !UsuarioBL.HayUsuarios();
            ViewBag.Primero = primero;
            return View(new Usuario());
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("Correo,Clave")] Usuario pUsuario, string confirmarClave)
        {
            bool primero = !UsuarioBL.HayUsuarios();
            ViewBag.Primero = primero;

            if (pUsuario.Clave != confirmarClave)
                ModelState.AddModelError("confirmarClave", "Las contraseñas no coinciden.");

            if (!ModelState.IsValid)
                return View(pUsuario);

            try
            {
                int resultado = UsuarioBL.Guardar(pUsuario);
                TempData["Mensaje"] = "Usuario registrado correctamente.";
                if (User.IsInRole("Administrador"))
                    return RedirectToAction("Index", "Inicio");

                return RedirectToAction(nameof(Login));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pUsuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pUsuario);
            }
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        [HttpGet, AllowAnonymous]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return Content("No se pudo completar la operación. Revise la configuración con el docente.");
        }
    }
}