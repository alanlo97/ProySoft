using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProySoft.Data;
using ProySoft.Dto;
using ProySoft.Models;

namespace ProySoft.Controllers
{
    public class BurgersController : Controller
    {
        private readonly ProySoftContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public BurgersController(ProySoftContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Burgers
        public async Task<IActionResult> Index(int searchByTipo)
        {
            if(_context.Burgers != null)
            {
                var response = await _context.Burgers.ToListAsync();

                if(searchByTipo > 0)
                {
                    var burgers = response.Where(x => x.IdTipoProducto == searchByTipo);

                    return View(burgers);
                }
                



                /*var list = new List<BurgerDto>();

                foreach(var item in burger)
                {
                    var dto = new BurgerDto
                    {
                        Ingredientes = item.Ingredientes,
                        Name = item.Name,
                        Id = item.Id,
                    };

                    list.Add(dto);
                }  */

                return View(response);
            }
            else
            {
                return Problem("Entity set 'ProySoftContext.Burger'  is null.");
            }
        }

        // GET: Burgers/Details/5
        public async Task<IActionResult> Details(int? id)
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

            /*var dto = new ComboDetailDto
            {
                Imagen = burger.Imagen,
                Ingredientes = burger.Ingredientes,
                Name = burger.Name,
                Price = burger.Price
            };  */

            return View(burger);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,Ingredientes,IdTipoProducto")] BurgerDto dto)
        {
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(dto);

                var burger = new Burger
                {
                    Ingredientes = dto.Ingredientes,
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                    Imagen = stringFileName,
                    Price = dto.Price
                    
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
                using(var fileStream = new FileStream(filePath, FileMode.Create))
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
                Ingredientes= burger.Ingredientes,
                Price = burger.Price,
            };

            return View(dto);
        }

        // POST: Burgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagen,Ingredientes")] BurgerDto dto)
        {
            if (id !=dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string stringFileName = UploadFile(dto);
                    /*var burger = new Burger
                    {
                        Imagen = stringFileName,
                        Name = dto.Name,
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                        Ingredientes = dto.Ingredientes,
                        Price= dto.Price,
                        IdTipoProducto= dto.IdTipoProducto,
                    };*/

                    var burger = await _context.Burgers.FindAsync(id);
                    burger.Ingredientes = dto.Ingredientes;
                    burger.Price = dto.Price;

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
                Price = burger.Price,
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
        }
    }
}
