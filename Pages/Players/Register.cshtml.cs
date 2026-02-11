using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamNaGuara.Models;

namespace TeamNaGuara.Pages.Players
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Player Player { get; set; } = new();

        [BindProperty]
        public IFormFile? Photo { get; set; }

        [BindProperty]
        public IFormFile? DocumentImage { get; set; }

        public void OnGet()
        {
            // Cargar datos necesarios para la página (ej. equipos)
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            // Guardar Player y archivos...
            return RedirectToPage("/Index");
        }
    }
}