
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jogo.Data;
using Jogo.Models;

namespace Jogo.Controllers
{
    public class PlacarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Placar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Placar.Include(p => p.Jogador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Placar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Jogador)
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // GET: Placar/Create
        public IActionResult Create()
        {
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "JogadorId", "JogadorId");
            return View();
        }

        // POST: Placar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacarId,JogadorId,Pontos,Data")] Placar placar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "JogadorId", "JogadorId", placar.JogadorId);
            return View(placar);
        }

        // GET: Placar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar.FindAsync(id);
            if (placar == null)
            {
                return NotFound();
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "JogadorId", "JogadorId", placar.JogadorId);
            return View(placar);
        }

        // POST: Placar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacarId,JogadorId,Pontos,Data")] Placar placar)
        {
            if (id != placar.PlacarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacarExists(placar.PlacarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "JogadorId", "JogadorId", placar.JogadorId);
            return View(placar);
        }

        // GET: Placar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Jogador)
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // POST: Placar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placar = await _context.Placar.FindAsync(id);
            _context.Placar.Remove(placar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacarExists(int id)
        {
            return _context.Placar.Any(e => e.PlacarId == id);
        }
    }
}
