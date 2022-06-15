using System.ComponentModel.DataAnnotations;

namespace ProySoft.Models
{
    public class TipoProducto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
