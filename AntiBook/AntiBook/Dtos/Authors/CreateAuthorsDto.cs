using System.ComponentModel.DataAnnotations;

namespace AntiBook.Dtos.Authors
{
    public class CreateAuthorsDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
    }
}
