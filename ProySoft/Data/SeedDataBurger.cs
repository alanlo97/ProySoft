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
                        Imagen = "739d90aa-ef4d-4ace-8912-d525f0f64993-big mac.jpg",
                        Ingredientes = "Quizás sean las dos hamburguesas de carne 100% vacuna con esa salsa especial y queso derretido, el toque de cebolla y la frescura de la lechuga o el crocante del pepino, lo que la hace la hamburguesa más famosa del mundo. Un sabor único.",
                        IsDeleted = false,
                        Price = 22.22,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "McNifica",
                        CreateTime = DateTime.Now,
                        Imagen = "3efa0bdd-82c7-4f0f-b719-a136c22d93cf-mcnifica.jpg",
                        Ingredientes = "En un mundo donde todos buscan lo nuevo todo el tiempo, la McNífica viene a rectificar lo bueno de ser clásico. Carne, queso cheddar, tomate, lechuga y cebolla, acompañados de kétchup, mostaza y mayonesa.",
                        IsDeleted = false,
                        Price = 28.2,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "McFiesta",
                        CreateTime = DateTime.Now,
                        Imagen = "bd88d3c0-b483-4112-b5a6-4e637580bdf6-mcfiesta.jpg",
                        Ingredientes = "Hamburguesa elaborada con carne 100% de carne vacuna, mayonesa, lechuga, tomate.",
                        IsDeleted = false,
                        Price = 30.5,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "Grand Triple Bacon",
                        CreateTime = DateTime.Now,
                        Imagen = "093dd330-2b9f-4b2d-8b75-3a8173ef4ae7-1704 GRAND TRIPLE McBACON SOLO.png",
                        Ingredientes = "¡NUEVO PAN! Triple carne, inigualable queso cheddar, cebolla, kétchup y mostaza, y el increíble ingrediente que lo hace único: bacon premium",
                        IsDeleted = false,
                        Price = 450,
                        IdTipoProducto = 1
                    },

                    new Burger
                    {
                        Name = "Cafe con leche y medialunas",
                        CreateTime= DateTime.Now,
                        Imagen = "2ad02d34-e406-4e07-bec5-6e7cd3e34905-cafe.png",
                        Ingredientes = "La mejor selección de finos granos de café arábicos en todo su esplendor, para que disfrutes sorbo a sorbo.",
                        IsDeleted= false,
                        Price = 12.02,
                        IdTipoProducto = 2
                    },

                    new Burger
                    {
                         Name = "Sundae de Dulce de Leche",
                         CreateTime = DateTime.Now,
                         Imagen = "20a2209f-eadd-4072-9be4-2e3dd2c032bc-sandae.png",
                         Ingredientes = "El exquisito helado de vainilla que ya conoces y te encanta, pero bañado de una salsa de dulce de leche que te encantará aún más.",
                         IsDeleted = false,
                        Price = 15.02,
                        IdTipoProducto = 3
                    },

                    new Burger
                    {
                        Name = "Coca-Cola",
                        CreateTime = DateTime.Now,
                        Imagen = "9babbef8-9e89-46e1-9d51-39b0346f2d6e-t-mcdonalds-Coca-Cola-Classic-Small-1_1-3-product-tile-desktop.jpg",
                        Ingredientes = "Burbujas contra el calor, contra la sed, contra el aburrimiento. Si tus comidas llevan gaseosa, están listas para enfrentar lo que sea, elegila en tamaño regular, mediano o grande.",
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
