using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OgretmenController : Controller
{

    private readonly DataContext _context;
    public OgretmenController(DataContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {

        return View(await _context.Ogretmenler.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Ogretmen model)
    {
        _context.Ogretmenler.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }



    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var teacher = await _context.Ogretmenler.FirstOrDefaultAsync(o => o.OgretmenId == id);
        // var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciId == id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ogretmen model)
    {
        if (id != model.OgretmenId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(model);
    }




}