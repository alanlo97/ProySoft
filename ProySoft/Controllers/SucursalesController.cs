using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProySoft.Data;
using ProySoft.Dto;

namespace ProySoft.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ProySoftContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SucursalesController(ProySoftContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Sucursales
        public async Task<IActionResult> Index()
        {
            if (_context.Sucursales != null)
            {
                var sucursal = await _context.Sucursales.ToListAsync();

                /*var list = new List<SucursalesDto>();

                foreach(var item in sucursal)
                {
                    var dto = new SucursalesDto
                    {
                        Ingredientes = item.Ingredientes,
                        Name = item.Name,
                    };

                    list.Add(dto);
                }*/

                return View(sucursal);
            }
            else
            {
                return Problem("Entity set 'ProySoftContext.Sucursales'  is null.");
            }
        }

        // GET: Sucursales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucursales == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            var dto = new SucursalesDto
            {
                Calle = sucursal.Calle,
                Email = sucursal.Email,
                Localidad = sucursal.Localidad,
                Name = sucursal.Name,
                Provincia = sucursal.Provincia,
                Telefono = sucursal.Telefono,
            };

            return View(dto);
        }

        // GET: Sucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,Ingredientes")] SucursalesDto dto)
        {
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(dto);

                var sucursal = new Sucursales
                {
                    Ingredientes = dto.Ingredientes,
                    Name = dto.Name,
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                    Imagen = stringFileName
                };

                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        private string UploadFile(SucursalesDto dto)
        {
            string fileName = null;
            if (dto.Imagen != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + dto.Imagen.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.Imagen.CopyTo(fileStream);
                }

            }

            return fileName;
        }

        // GET: Sucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucursales == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            var dto = new SucursalesDto
            {
                Name = sucursal.Name,
                Ingredientes = sucursal.Ingredientes,
            };

            return View(dto);
        }

        // POST: Sucursales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imagen,Ingredientes")] SucursalesDto dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sucursal = new Sucursales
                    {
                        //Imagen = dto.Imagen,
                        Name = dto.Name,
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                        Ingredientes = dto.Ingredientes,
                    };
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalesExists(dto.Id))
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
            return View(dto);
        }

        // GET: Sucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sucursales == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            var dto = new SucursalesDto
            {
                Ingredientes = sucursal.Ingredientes,
                Name = sucursal.Name,
            };

            return View(dto);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sucursales == null)
            {
                return Problem("Entity set 'ProySoftContext.Sucursales'  is null.");
            }
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal != null)
            {
                _context.Sucursales.Remove(sucursal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalesExists(int id)
        {
            return (_context.Sucursales?.Any(e => e.Id == id)).GetValueOrDefault();
        } */
    }
}
