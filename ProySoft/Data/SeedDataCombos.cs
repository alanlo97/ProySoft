using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public static class SeedDataCombos
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProySoftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProySoftContext>>()))
            {
                // Look for any movies.
                if (context.Combos.Any())
                {
                    return;   // DB has been seeded
                }

                context.Combos.AddRange(
                    new Combos
                    {
                        Name = "Combo Big Mac",
                        CreateTime = DateTime.Now,
                        Imagen = "664c57bd-7787-4c2e-8d0b-4a053d755a92-big mac combo.jpg",
                        IsDeleted = false,
                        Price = 22.22
                    },

                    new Combos
                    {
                        Name = "Combo McNifica",
                        CreateTime = DateTime.Now,
                        Imagen = "ab728a03-0181-4458-b209-e71c04dc1d85-combo-mcnifica.jpg",
                        IsDeleted = false,
                        Price = 28.2
                    },

                    new Combos
                    {
                        Name = "Combo McFiesta",
                        CreateTime = DateTime.Now,
                        Imagen = "7c32bfa6-80ad-4fde-b567-7ac1dc585052-combo-mcfiesta.jpg",
                        IsDeleted = false,
                        Price = 30.5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
