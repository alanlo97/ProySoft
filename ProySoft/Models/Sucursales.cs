using System.ComponentModel.DataAnnotations;

namespace ProySoft.Models
{
    public class Sucursales
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Calle { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
