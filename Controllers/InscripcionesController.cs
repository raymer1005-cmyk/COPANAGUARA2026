using Microsoft.AspNetCore.Mvc;
using TeamNaGuara.Models;
using System.IO;

namespace TeamNaGuara.Controllers
{
    public class InscripcionesController : Controller
    {
        // Método que muestra el formulario (GET)
        [HttpGet]
        public IActionResult RegistrarEquipo()
        {
            return View();
        }

        // Método que procesa el formulario (POST)
        [HttpPost]
        public IActionResult RegistrarEquipo(Team model, IFormFile logo)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (logo != null && logo.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var filePath = Path.Combine(uploads, Path.GetFileName(logo.FileName));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    logo.CopyTo(stream);
                }

                model.LogoPath = "/uploads/" + logo.FileName;
            }

            ViewBag.Mensaje = "Equipo registrado con éxito.";
            return View(model);
        }
    }
}
