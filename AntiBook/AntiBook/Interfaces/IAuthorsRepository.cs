using AntiBook.Dtos.Authors;
using AntiBook.Dtos.Books;
using AntiBook.Helpers;
using AntiBook.Models;

namespace AntiBook.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<List<Authors>> GetAllAsync(QueryObject query);
        Task<Authors?> GetByIdAsync(int id);
        Task<Authors> CreateAsync(Authors authorsModel);
        Task<Authors?> UpdateAsync(int id, UpdateAuthorsDto authorsDto);
        Task<Authors?> DeleteAsync(int id);
        Task<bool> AuthorExists(int id);
    }
}
