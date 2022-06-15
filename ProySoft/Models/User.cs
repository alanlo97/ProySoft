using System.ComponentModel.DataAnnotations;

namespace ProySoft.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Dni { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public string Password { get; set; }
    }
}
