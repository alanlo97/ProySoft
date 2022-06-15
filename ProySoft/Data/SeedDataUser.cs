using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public static class SeedDataUser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProySoftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProySoftContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Name = "Admin",
                        Dni = 11111111,
                        Email = "admin@admin.com",
                        CreateTime = DateTime.Now,
                        IsDeleted = false ,
                        Password = "Admin123",
                        UserName = "Admin"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
