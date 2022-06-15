using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProySoft.Data;
using ProySoft.Dto;
using ProySoft.Helper;
using ProySoft.Helper.Interface;
using ProySoft.Models;

namespace ProySoft.Controllers
{
    public class CombosController  : Controller
    {
        private readonly ProySoftContext _context;

        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CombosController(ProySoftContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: Combos
        public async Task<IActionResult> Index()
        {
            if (_context.Combos != null)
            {
                var combos = await _context.Combos.ToListAsync();

                /*var list = new List<CombosDto>();

                foreach(var item in combos)
                {
                    var dto = new CombosDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Imagen = item.Imagen,
                        Price = item.Price,
                    };

                    list.Add(dto);
                }   */

                return View(combos);
            }
            else
            {
                return Problem("Entity set 'ProySoftContext.Combos'  is null.");
            }
        }

        // GET: Combos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combos = await _context.Combos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combos == null)
            {
                return NotFound();
            }

            var dto = new ComboDetailDto
            {
                Id  = combos.Id,
                Name = combos.Name,
                Imagen = combos.Imagen,
                Price = combos.Price,
            };

            return View(dto);
        }

        // GET: Combos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Combos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,Ingredientes")] CombosDto dto)
        {
            if (ModelState.IsValid)
            {
                string stringFileName = String.Empty;//UploadFile(dto);

                var combos = new Combos
                {
                    Name =dto.Name,
                    //Imagen = dto.Imagen,
                    Price = dto.Price,
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                    //Imagen = stringFileName
                };

                _context.Add(combos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        private string UploadFile(CombosDto dto)
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

        // GET: Combos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combos = await _context.Combos.FindAsync(id);
            if (combos == null)
            {
                return NotFound();
            }

            var dto = new CombosDto
            {
                Name = combos.Name,
                //Imagen = combos.Imagen,
                Price = combos.Price,
            };

            return View(dto);
        }

        // POST: Combos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imagen,Ingredientes,Price")] CombosDto dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string stringFileName = UploadFile(dto);
                    /*var combos = new Combos
                    {
                        //Imagen = dto.Imagen,
                        Name = dto.Name,
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                    };*/

                    var combos = await _context.Combos.FindAsync(id);

                    combos.Imagen = stringFileName;
                    combos.Name = dto.Name;

                    _context.Update(combos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombosExists(dto.Id))
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

        public async Task<IActionResult> CreateCupon(ComboDetailDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var email = new Email(_configuration);
                    await email.SendEmailWithTemplateAsync(dto.Email);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombosExists(dto.Id))
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Combos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combos = await _context.Combos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combos == null)
            {
                return NotFound();
            }

            var dto = new CombosDto
            {
                Name = combos.Name,
                //Imagen = combos.Imagen,
                Price = combos.Price,
            };

            return View(dto);
        }

        // POST: Combos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Combos == null)
            {
                return Problem("Entity set 'ProySoftContext.Combos'  is null.");
            }
            var combos = await _context.Combos.FindAsync(id);
            if (combos != null)
            {
                _context.Combos.Remove(combos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombosExists(int id)
        {
            return (_context.Combos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
