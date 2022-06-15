using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public static class SeedDataBurger
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProySoftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProySoftContext>>()))
            {
                // Look for any movies.
                if (context.Burgers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Burgers.AddRange(
                    new Burger
                    {
                        Name = "Big Mac",
                        CreateTime = DateTime.Now,
                        Imagen = "Big Mac Imagen",
                        Ingredientes = "Big Mac Ingredientes",
                        IsDeleted = false,
                        Price = 22.22,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "McNifica",
                        CreateTime = DateTime.Now,
                        Imagen = "McNifica Imagen",
                        Ingredientes = "McNifica Ingredientes",
                        IsDeleted = false,
                        Price = 28.2,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "McFiesta",
                        CreateTime = DateTime.Now,
                        Imagen = "McFiesta Imagen",
                        Ingredientes = "McFiesta Ingredientes",
                        IsDeleted = false,
                        Price = 30.5,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "Cafe con leche y medialunas",
                        CreateTime= DateTime.Now,
                        Imagen = "Cafe con leche y medialunas Imagen",
                        Ingredientes = "Cafe con leche ingredientes",
                        IsDeleted= false,
                        Price = 12.02,
                        IdTipoProducto = 2
                    },

                    new Burger
                    {
                         Name = "Sundae de Dulce de Leche",
                         CreateTime = DateTime.Now,
                         Imagen = "Sundar Imagen",
                         Ingredientes = "Sundae ingredientes",
                         IsDeleted = false,
                        Price = 15.02,
                        IdTipoProducto = 3
                    },

                    new Burger
                    {
                        Name = "Coca-Cola",
                        CreateTime = DateTime.Now,
                        Imagen = "Coca-Cola Imagen",
                        Ingredientes = "Coca-Cola ingredientes",
                        IsDeleted = false,
                        Price = 10.20,
                        IdTipoProducto = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
