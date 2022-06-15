using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public static class SeedDataSucursal
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProySoftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProySoftContext>>()))
            {
                // Look for any movies.
                if (context.Sucursales.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sucursales.AddRange(
                    new Sucursales
                    {
                        Name = "Sucurnal Lanus",
                        Calle = "29 de Septiembre",
                        Localidad = "Lanus",
                        Provincia = "Buenos Aires",
                        Email = "lanus@mcdonalds.com",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new Sucursales
                    {
                        Name = "Sucurnal Ezeiza",
                        Calle = "Av. Uriarte",
                        Localidad = "Ezeiza",
                        Provincia = "Buenos Aires",
                        Email = "bautiberto@gmail.com",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new Sucursales
                    {
                        Name = "Sucurnal Lomas",
                        Calle = "Malabia",
                        Localidad = "Lomas",
                        Provincia = "Buenos Aires",
                        Email = "lomas@mcdonalds.com",
                        IsDeleted = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
