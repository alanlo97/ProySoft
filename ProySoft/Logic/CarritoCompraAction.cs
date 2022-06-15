using ProySoft.Data;
using ProySoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProySoft.Logic
{
    public class CarritoCompraAction : IDisposable
    {
        public string CarritoCompraId { get; set; }

        private readonly ProySoftContext _context;

        public const string CarritoSessionKey = "CarritoId";

        private readonly IHttpContextAccessor _contextAccessor;

        public CarritoCompraAction(ProySoftContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            CarritoCompraId = GetCartId();

            var cartItem = _context.Carritos.SingleOrDefault(
                c => c.CarritoId == CarritoCompraId
                && c.BurgerId == id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new Carrito
                {
                    ItemId = Guid.NewGuid().ToString(),
                    BurgerId = id,
                    CarritoId = CarritoCompraId,
                    Burger = _context.Burgers.SingleOrDefault(
                        p => p.Id == id),
                    Cantidad = 1,
                    Create = DateTime.Now
                };

                _context.Carritos.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Cantidad++;
            }
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                //_context = null;
            }
        }

        public string GetCartId()
        {
            if (_contextAccessor.HttpContext.Session.GetString(CarritoSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(_contextAccessor.HttpContext.User.Identity.Name))
                {
                    _contextAccessor.HttpContext.Session.SetString(CarritoSessionKey, _contextAccessor.HttpContext.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    _contextAccessor.HttpContext.Session.SetString(CarritoSessionKey, tempCartId.ToString());
                }
            }
            return _contextAccessor.HttpContext.Session.GetString(CarritoSessionKey);
        }

        public List<Carrito> GetCartItems()
        {
            CarritoCompraId = GetCartId();

            return _context.Carritos.Where(
                c => c.CarritoId == CarritoCompraId).ToList();
        }
    }
}
