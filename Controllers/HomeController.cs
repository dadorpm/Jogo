
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jogo.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Jogo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
  

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Placar.Include(p => p.Jogador).OrderByDescending(p => p.Pontos).Take(10);
            return View(await applicationDbContext.ToListAsync());
        }

    
    }
}
