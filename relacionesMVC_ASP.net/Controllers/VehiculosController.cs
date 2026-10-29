
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relacionesMVC_ASP.net.Models;

public class VehiculosController : Controller
{
    private readonly VehiculoDbContext _context;

    public VehiculosController(VehiculoDbContext context)
    {
        _context = context;
    }

    // GET: VEHICULOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Vehiculo.ToListAsync());
    }

    // GET: VEHICULOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculo = await _context.Vehiculo
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculo == null)
        {
            return NotFound();
        }

        return View(vehiculo);
    }

    // GET: VEHICULOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: VEHICULOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Capacidad,Color,AnioFabricacion,Precio")] Vehiculo vehiculo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vehiculo);
    }

    // GET: VEHICULOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculo = await _context.Vehiculo.FindAsync(id);
        if (vehiculo == null)
        {
            return NotFound();
        }
        return View(vehiculo);
    }

    // POST: VEHICULOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Marca,Modelo,Capacidad,Color,AnioFabricacion,Precio")] Vehiculo vehiculo)
    {
        if (id != vehiculo.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vehiculo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(vehiculo.Id))
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
        return View(vehiculo);
    }

    // GET: VEHICULOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculo = await _context.Vehiculo
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculo == null)
        {
            return NotFound();
        }

        return View(vehiculo);
    }

    // POST: VEHICULOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var vehiculo = await _context.Vehiculo.FindAsync(id);
        if (vehiculo != null)
        {
            _context.Vehiculo.Remove(vehiculo);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VehiculoExists(int? id)
    {
        return _context.Vehiculo.Any(e => e.Id == id);
    }
}
