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
                        Calle = "Calle de Sucursal Lanus",
                        Localidad = "Localidad de Sucursal Lanus",
                        Provincia = "Provincia de Sucursal Lanus",
                        Email = "lanus@mcdonalds.com",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new Sucursales
                    {
                        Name = "Sucurnal Ezeiza",
                        Calle = "Calle de Sucursal Ezeiza",
                        Localidad = "Localidad de Sucursal Ezeiza",
                        Provincia = "Provincia de Sucursal Ezeiza",
                        Email = "bautiberto@gmail.com",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    },

                    new Sucursales
                    {
                        Name = "Sucurnal Lomas",
                        Calle = "Calle de Sucursal Lomas",
                        Localidad = "Localidad de Sucursal Lomas",
                        Provincia = "Provincia de Sucursal Lomas",
                        Email = "lomas@mcdonalds.com",
                        IsDeleted = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
