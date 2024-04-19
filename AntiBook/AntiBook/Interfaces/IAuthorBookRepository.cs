using AntiBook.Models;

namespace AntiBook.Interfaces
{
    public interface IAuthorBookRepository
    {
        Task<List<Books>> GetAuthorBook();

    }
}
