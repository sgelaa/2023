using System.ComponentModel.DataAnnotations;

namespace BookNation.DataAccess.DTO
{
    public class AuthorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
