using AntiBook.Dtos.Books;
using AntiBook.Models;

namespace AntiBook.Interfaces
{
    public interface IBooksRepository
    {
        Task<List<Books>> GetAllAsync();
        Task<Books?> GetByIdAsync(int id); //FirstOrDefalt CAN BE NULL
        Task<Books> CreateAsync(Books bookModel);
        Task<Books?> UpdateAsync(int id, UpdateBooksRequestDto bookDto);
        Task<Books?> DeleteAsync(int id);
    }
}
