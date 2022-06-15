using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.EntityFrameworkCore;
using ProySoft.Areas.Identity.Data;
using ProySoft.Areas.Identity.Pages.Account;
using ProySoft.Data;
using ProySoft.Dto;
using ProySoft.Helper;
using ProySoft.Models;

namespace ProySoft.Controllers
{
    [Route("Carrito")]
    public class CarritoController : Controller
    {
        private readonly ProySoftContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly SignInManager<Usuarios> _signInManager;

        private readonly ILogger<LoginModel> _logger;

        public CarritoController(ProySoftContext context, IWebHostEnvironment webHostEnvironment, SignInManager<Usuarios> signInManager, ILogger<LoginModel> logger)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;

            if(cart == null)
            {
                return RedirectToAction("Index", "Combos");
            }

            var sucursales = await _context.Sucursales.ToListAsync();

            ViewBag.total = cart.Sum(item => item.Combos.Price * item.Cantidad);
            return View(sucursales);
        }

        [Route("buy/{id}")]
        public async Task<IActionResult> Buy(int id)
        {
            CombosDto combos = new CombosDto();

            if(SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                var response = await _context.Combos.FindAsync(id);

                var combo = new Combos
                {
                    Id = response.Id,
                    Imagen = response.Imagen,
                    Name = response.Name,
                    Price = response.Price,

                };

                cart.Add(new Item { Combos = combo, Cantidad = 1} );
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Cantidad++;
                }
                else
                {
                    cart.Add(new Item { Combos = await _context.Combos.FindAsync(id), Cantidad = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Combos");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Combos.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        // GET: Burgers
        /*public async Task<IActionResult> Index()
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
                }

                return View(burger);
            }
            else
            {
                return Problem("Entity set 'ProySoftContext.Burger'  is null.");
            }
        } */

        // GET: Burgers/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var burger = await _context.Carritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            var dto = new CarritoDto
            {
                Ingredientes = burger.Ingredientes,
                Name = burger.Name,
            };

            return View(dto);
        }  */

        // GET: Burgers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        public JsonResult InsertarCarrito(CombosDto dto)
        {
            var carrito = new Carrito();

            var usuario = (Usuarios)_signInManager.IsSignedIn(Usuarios);
        } */

        /*private string UploadFile(BurgerDto dto)
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
        }   */
    }
}
