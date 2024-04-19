using AntiBook.Dtos.Books;

namespace AntiBook.Dtos.Authors
{
    public class AuthorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<BooksDto> Books { get; set; }
    }
}
