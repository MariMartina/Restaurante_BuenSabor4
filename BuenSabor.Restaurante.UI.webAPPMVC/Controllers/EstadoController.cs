using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuenSabor.Restaurante.UI.webAPPMVC.Controllers
{
    public class Estado : Controller
    {
        public object EstadoBL { get; private set; }

        // GET: estadoController
        public ActionResult Index(string BuscarNombre)
        {
            List<Estado> estados = EstadoBL.ObtenerTodos();
            ViewData["CurrentFilter"] = BuscarNombre;

            if (!string.IsNullOrWhiteSpace(BuscarNombre))
            {
                var filtered = estados.Where(e => !string.IsNullOrEmpty(e.Nombre) && e.Nombre.Contains(BuscarNombre, StringComparison.OrdinalIgnoreCase)).ToList();
                return View();
            }
            return View();
        }

        // GET: estadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: estadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: estadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: estadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: estadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: estadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
