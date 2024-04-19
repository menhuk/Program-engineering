using AntiBook.Data;
using AntiBook.Interfaces;
using AntiBook.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using AntiBook.Controllers;
using static AntiBook.Data.ApplicationDBContext;
using AntiBook.Mappers;
using AntiBook.Dtos;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AntiBook.Dtos.Authors;
using AntiBook.Dtos.Books;
using AntiBook.Helpers;
namespace AntiBook.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ApplicationDBContex _context;

        public AuthorsRepository(ApplicationDBContex context)
        {
            _context = context;
        }

        public async Task<List<Authors>> GetAllAsync(QueryObject query)
        {
            var authors = _context.Authors.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                authors = authors.Where(s=>s.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.Surname))
            {
                authors = authors.Where(s => s.Surname.Contains(query.Surname));
            }
            return await authors.ToListAsync();
        }

        public async Task<Authors?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public async Task<Authors> CreateAsync(Authors authorsModel)
        {
            await _context.Authors.AddAsync(authorsModel);
            await _context.SaveChangesAsync();
            return authorsModel;
        }
        public async Task<Authors?> DeleteAsync(int id)
        {
            var authorsModel = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (authorsModel == null)
            {
                return null;
            }
            _context.Authors.Remove(authorsModel);
            await _context.SaveChangesAsync();
            return authorsModel;
        }

        public async Task<Authors?> UpdateAsync(int id, UpdateAuthorsDto authorsDto)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAuthor == null)
            {
                return null;
            }
            existingAuthor.Name = authorsDto.Name;
            existingAuthor.Surname = authorsDto.Surname;
            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public Task<bool> AuthorExists(int id)
        {
            return _context.Authors.AnyAsync(s=>s.Id == id);
        }
    }
}
