using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProySoft.Data;

namespace ProySoft.Controllers
{
    public class TipoProductoController : Controller
    {
        private readonly ProySoftContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public TipoProductoController(ProySoftContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Burgers
        public async Task<IActionResult> Index()
        {
            if (_context.Burgers != null)
            {
                var burger = await _context.Burgers.ToListAsync();

                /*var list = new List<BurgerDto>();

                foreach(var item in burger)
                {
                    var dto = new BurgerDto
                    {
                        Ingredientes = item.Ingredientes,
                        Name = item.Name,
                    };

                    list.Add(dto);
                }*/

                return View(burger);
            }
            else
            {
                return Problem("Entity set 'ProySoftContext.Burger'  is null.");
            }
        }

        // GET: Burgers/Details/5
       /* public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Burgers == null)
            {
                return NotFound();
            }

            var burger = await _context.Burgers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            var dto = new BurgerDto
            {
                Ingredientes = burger.Ingredientes,
                Name = burger.Name,
            };

            return View(dto);
        }

        // GET: Burgers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,Ingredientes")] BurgerDto dto)
        {
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(dto);

                var burger = new Burger
                {
                    Ingredientes = dto.Ingredientes,
                    Name = dto.Name,
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                    Imagen = stringFileName
                };

                _context.Add(burger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        private string UploadFile(BurgerDto dto)
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

        // GET: Burgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Burgers == null)
            {
                return NotFound();
            }

            var burger = await _context.Burgers.FindAsync(id);
            if (burger == null)
            {
                return NotFound();
            }

            var dto = new BurgerDto
            {
                Name = burger.Name,
                Ingredientes = burger.Ingredientes,
            };

            return View(dto);
        }

        // POST: Burgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imagen,Ingredientes")] BurgerDto dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var burger = new Burger
                    {
                        //Imagen = dto.Imagen,
                        Name = dto.Name,
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                        Ingredientes = dto.Ingredientes,
                    };
                    _context.Update(burger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerExists(dto.Id))
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

        // GET: Burgers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Burgers == null)
            {
                return NotFound();
            }

            var burger = await _context.Burgers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            var dto = new BurgerDto
            {
                Ingredientes = burger.Ingredientes,
                Name = burger.Name,
            };

            return View(dto);
        }

        // POST: Burgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Burgers == null)
            {
                return Problem("Entity set 'ProySoftContext.Burger'  is null.");
            }
            var burger = await _context.Burgers.FindAsync(id);
            if (burger != null)
            {
                _context.Burgers.Remove(burger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurgerExists(int id)
        {
            return (_context.Burgers?.Any(e => e.Id == id)).GetValueOrDefault();
        } */
    }
}
