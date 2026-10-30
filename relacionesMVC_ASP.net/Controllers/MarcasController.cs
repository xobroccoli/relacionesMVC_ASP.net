
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relacionesMVC_ASP.net.Models;

public class MarcasController : Controller
{
    private readonly VehiculoDbContext _context;

    public MarcasController(VehiculoDbContext context)
    {
        _context = context;
    }

    // GET: MARCAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Marca.ToListAsync());
    }

    // GET: MARCAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marca = await _context.Marca
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marca == null)
        {
            return NotFound();
        }

        return View(marca);
    }

    // GET: MARCAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MARCAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,PaisOrigen,AnioFundacion,Vehiculos")] Marca marca)
    {
        if (ModelState.IsValid)
        {
            _context.Add(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(marca);
    }

    // GET: MARCAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marca = await _context.Marca.FindAsync(id);
        if (marca == null)
        {
            return NotFound();
        }
        return View(marca);
    }

    // POST: MARCAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,PaisOrigen,AnioFundacion,Vehiculos")] Marca marca)
    {
        if (id != marca.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(marca.Id))
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
        return View(marca);
    }

    // GET: MARCAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marca = await _context.Marca
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marca == null)
        {
            return NotFound();
        }

        return View(marca);
    }

    // POST: MARCAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var marca = await _context.Marca.FindAsync(id);
        if (marca != null)
        {
            _context.Marca.Remove(marca);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MarcaExists(int? id)
    {
        return _context.Marca.Any(e => e.Id == id);
    }
}
