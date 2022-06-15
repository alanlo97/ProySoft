using System.ComponentModel.DataAnnotations;

namespace ProySoft.Dto
{
    public class ComboDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Imagen { get; set; }

        public double Price { get; set; }

        [Required(ErrorMessage = "The DNI Is Required")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "The Email Is Required")]
        [StringLength(maximumLength: 320, ErrorMessage = "The Email Is Too Long")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
    }
}
