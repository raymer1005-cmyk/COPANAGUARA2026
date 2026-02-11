using Microsoft.AspNetCore.Mvc;
using TeamNaGuara.Models;
using System.IO;

namespace TeamNaGuara.Controllers
{
    public class TeamController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Team model, IFormFile logo)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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

            ViewBag.Message = "Equipo registrado con éxito";
            return View("Register", model);
        }
    }
}
