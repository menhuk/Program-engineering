using AntiBook.Data;
using AntiBook.Interfaces;
using AntiBook.Models;
using static AntiBook.Data.ApplicationDBContext;

namespace AntiBook.Repository
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly ApplicationDBContex _context;
        public AuthorBookRepository(ApplicationDBContex context )
        {
            _context = context;
        }

        public Task<List<Books>> GetAuthorBook()
        {
            throw new NotImplementedException();
        }
    }
}
