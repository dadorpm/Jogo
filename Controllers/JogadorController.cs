
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jogo.Data;
using Jogo.Models;

namespace Jogo.Controllers
{
    public class JogadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JogadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jogador
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogador.Include(j => j.Nacionalidade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jogador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Nacionalidade)
                .FirstOrDefaultAsync(m => m.JogadorId == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogador/Create
        public IActionResult Create()
        {
            ViewData["NacionalidadeId"] = new SelectList(_context.Set<Nacionalidade>(), "NacionalidadeId", "NacionalidadeId");
            return View();
        }

        // POST: Jogador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JogadorId,Nome,Idade,NacionalidadeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NacionalidadeId"] = new SelectList(_context.Set<Nacionalidade>(), "NacionalidadeId", "NacionalidadeId", jogador.NacionalidadeId);
            return View(jogador);
        }

        // GET: Jogador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["NacionalidadeId"] = new SelectList(_context.Set<Nacionalidade>(), "NacionalidadeId", "NacionalidadeId", jogador.NacionalidadeId);
            return View(jogador);
        }

        // POST: Jogador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JogadorId,Nome,Idade,NacionalidadeId")] Jogador jogador)
        {
            if (id != jogador.JogadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.JogadorId))
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
            ViewData["NacionalidadeId"] = new SelectList(_context.Set<Nacionalidade>(), "NacionalidadeId", "NacionalidadeId", jogador.NacionalidadeId);
            return View(jogador);
        }

        // GET: Jogador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Nacionalidade)
                .FirstOrDefaultAsync(m => m.JogadorId == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogador = await _context.Jogador.FindAsync(id);
            _context.Jogador.Remove(jogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
            return _context.Jogador.Any(e => e.JogadorId == id);
        }
    }
}
