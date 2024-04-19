namespace AntiBook.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public int city_id { get; set; }
        public string about_me { get; set; } = string.Empty;
    }
}
