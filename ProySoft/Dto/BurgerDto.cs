namespace ProySoft.Dto
{
    public class BurgerDto
    {
        public int Id { get; set; }

        public IFormFile Imagen { get; set; }

        public string Ingredientes { get; set; }

        public double Price { get; set; }
    }
}
