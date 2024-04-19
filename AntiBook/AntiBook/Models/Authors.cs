namespace AntiBook.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<AuthorBook> AuthorBook { get; set; } = new List<AuthorBook>();
    }
}
