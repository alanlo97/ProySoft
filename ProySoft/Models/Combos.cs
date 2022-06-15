using System.ComponentModel.DataAnnotations;

namespace ProySoft.Models
{
    public class Combos
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Imagen { get; set; }

        public double Price { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
