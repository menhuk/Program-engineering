namespace AntiBook.Dtos.Books
{
    public class UpdateBooksRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public int Current_owner_id { get; set; }
        public int Genre_id { get; set; }
        public int Secondary_genre_id { get; set; }
        public int Tertiary_genre_id { get; set; }
        public int Language_id { get; set; }
        public int Coverage_id { get; set; }
        public int Bookhouse_id { get; set; }
        public int City_id { get; set; }
        public int Translator_id { get; set; }
        public int Translation { get; set; }
        public long Pages { get; set; }
        public long Year { get; set; }
    }
}
