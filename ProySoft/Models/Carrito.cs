using System.ComponentModel.DataAnnotations;

namespace ProySoft.Models
{
    public class Carrito
    {
        [Key]
        public string ItemId { get; set; }
        public string CarritoId { get; set; }

        public int Cantidad { get; set; }

        public DateTime Create { get; set; }

        public int BurgerId { get; set; }

        public virtual Burger Burger { get; set; }

        public bool Closed { get; set; }
    }
}
