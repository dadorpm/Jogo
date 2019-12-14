
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jogo.Data;
using Jogo.Models;

namespace Jogo.Controllers
{
    public class NacionalidadeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NacionalidadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nacionalidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nacionalidade.ToListAsync());
        }

        // GET: Nacionalidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade
                .FirstOrDefaultAsync(m => m.NacionalidadeId == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // GET: Nacionalidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NacionalidadeId,Nome")] Nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidade);
        }

        // GET: Nacionalidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade.FindAsync(id);
            if (nacionalidade == null)
            {
                return NotFound();
            }
            return View(nacionalidade);
        }

        // POST: Nacionalidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NacionalidadeId,Nome")] Nacionalidade nacionalidade)
        {
            if (id != nacionalidade.NacionalidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacionalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadeExists(nacionalidade.NacionalidadeId))
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
            return View(nacionalidade);
        }

        // GET: Nacionalidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade
                .FirstOrDefaultAsync(m => m.NacionalidadeId == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // POST: Nacionalidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacionalidade = await _context.Nacionalidade.FindAsync(id);
            _context.Nacionalidade.Remove(nacionalidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalidadeExists(int id)
        {
            return _context.Nacionalidade.Any(e => e.NacionalidadeId == id);
        }
    }
}
