using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProySoft.Models
{
    public class Burger
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Imagen { get; set; }

        public string Ingredientes { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("TipoProducto")]
        public int IdTipoProducto { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }

        public double Price { get; set; }
    }
}
