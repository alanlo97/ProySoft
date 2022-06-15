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
                        Imagen = "Combo Big Mac Imagen",
                        IsDeleted = false,
                        Price = 22.22
                    },

                    new Combos
                    {
                        Name = "Combo McNifica",
                        CreateTime = DateTime.Now,
                        Imagen = "Combo McNifica Imagen",
                        IsDeleted = false,
                        Price = 28.2
                    },

                    new Combos
                    {
                        Name = "Combo McFiesta",
                        CreateTime = DateTime.Now,
                        Imagen = "Combo McFiesta Imagen",
                        IsDeleted = false,
                        Price = 30.5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
