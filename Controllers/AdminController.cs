using Microsoft.AspNetCore.Mvc;
using TeamNaGuara.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace TeamNaGuara.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db){ _db = db; }

        public async Task<IActionResult> Index()
        {
            var teams = await _db.Teams.Include(t => t.Players).ToListAsync();
            return View(teams);
        }

        public async Task<FileResult> ExportCsv()
        {
            var teams = await _db.Teams.Include(t => t.Players).ToListAsync();
            var sb = new StringBuilder();
            sb.AppendLine("TeamId,TeamName,PlayerId,PlayerName,Document,Position,PhotoPath,DocumentImagePath");
            foreach (var t in teams)
            foreach (var p in t.Players ?? new List<TeamNaGuara.Models.Player>())
            {
                sb.AppendLine($"{t.Id},\"{t.Name}\",{p.Id},\"{p.FullName}\",{p.DocumentNumber},{p.Position},\"{p.PhotoPath}\",\"{p.DocumentImagePath}\"");
            }
            var bytes = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "inscripciones_teamnaguara.csv");
        }
    }
}
