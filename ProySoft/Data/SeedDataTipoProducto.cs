using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public static class SeedDataTipoProducto
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProySoftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProySoftContext>>()))
            {
                // Look for any movies.
                if (context.TipoProductos.Any())
                {
                    return;   // DB has been seeded
                }

                context.TipoProductos.AddRange(
                    new TipoProducto
                    {
                        Name = "Hamburguesas",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new TipoProducto
                    {
                        Name = "Desayuno",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new TipoProducto
                    {
                        Name = "Postre",
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                    },

                    new TipoProducto
                    {
                        Name = "Gaseosa",
                        CreateTime = DateTime.Now,
                        IsDeleted = false,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
