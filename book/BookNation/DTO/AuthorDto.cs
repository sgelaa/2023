using System.ComponentModel.DataAnnotations;

namespace BookNation.DTO
{
    public class AuthorDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        [Required]
        public int ProductId { get; set; }
    }
}