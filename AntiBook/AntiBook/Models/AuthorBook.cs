namespace AntiBook.Models
{
    public class AuthorBook
    {
        public int AuthorsId { get; set; }
        public Authors Authors { get; set; }
        public int BooksId { get; set; }
        public Books Books { get; set; }
    }
}
