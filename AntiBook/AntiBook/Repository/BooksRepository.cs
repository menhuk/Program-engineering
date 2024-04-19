using AntiBook.Data;
using AntiBook.Dtos.Books;
using AntiBook.Interfaces;
using AntiBook.Models;
using Microsoft.EntityFrameworkCore;
using static AntiBook.Data.ApplicationDBContext;
namespace AntiBook.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDBContex _context;
        
        public BooksRepository(ApplicationDBContex context) 
        {
            _context = context;
        }

        public async Task<Books> CreateAsync(Books bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Books?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (bookModel == null) 
            {
                return null;
            }
            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Books>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Books?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Books?> UpdateAsync(int id, UpdateBooksRequestDto bookDto)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = bookDto.Title;
            existingBook.Year = bookDto.Year;
            existingBook.Current_owner_id = bookDto.Current_owner_id;
            existingBook.Genre_id = bookDto.Genre_id;
            existingBook.Secondary_genre_id = bookDto.Secondary_genre_id;
            existingBook.Tertiary_genre_id = bookDto.Tertiary_genre_id;
            existingBook.Pages = bookDto.Pages;
            existingBook.Bookhouse_id = bookDto.Bookhouse_id;
            existingBook.Coverage_id = bookDto.Coverage_id;
            existingBook.Language_id = bookDto.Language_id;
            existingBook.Translation = bookDto.Translation;
            existingBook.Translator_id = bookDto.Translator_id;
            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
