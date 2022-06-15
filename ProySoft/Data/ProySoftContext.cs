using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProySoft.Models;

namespace ProySoft.Data
{
    public class ProySoftContext : DbContext
    {
        public ProySoftContext (DbContextOptions<ProySoftContext> options)
            : base(options)
        {
        }

        public DbSet<ProySoft.Models.Burger>? Burgers { get; set; }

        public DbSet<ProySoft.Models.Combos>? Combos { get; set; }

        public DbSet<ProySoft.Models.Sucursales>? Sucursales { get; set; }

        public DbSet<ProySoft.Models.User>? Users { get; set; }

        public DbSet<ProySoft.Models.TipoProducto>? TipoProductos { get; set; }

        public DbSet<ProySoft.Models.Carrito>? Carritos { get; set; }
    }
}
