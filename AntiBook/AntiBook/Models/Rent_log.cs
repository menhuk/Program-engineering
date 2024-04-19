namespace AntiBook.Models
{
    public class Rent_log
    {
        public int Id { get; set; }
        public int lender_id { get; set; }
        public int borrowed_id { get; set; }
        public int book_id { get; set; }
    }
}
