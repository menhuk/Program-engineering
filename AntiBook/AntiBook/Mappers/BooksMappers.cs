using AntiBook.Dtos.Books;
using AntiBook.Models;

namespace AntiBook.Mappers
{
    public static class BooksMappers
    {
        public static BooksDto ToBooksDto(this Books bookModel)
        {
            return new BooksDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre_id = bookModel.Genre_id,
                Secondary_genre_id = bookModel.Secondary_genre_id,
                Tertiary_genre_id = bookModel.Tertiary_genre_id,
                Language_id = bookModel.Language_id,
                Coverage_id = bookModel.Coverage_id,
                Bookhouse_id = bookModel.Bookhouse_id,  
                City_id = bookModel.City_id,
                Translator_id = bookModel.Translator_id,
                Translation = bookModel.Translation,
                Pages = bookModel.Pages,
                Year = bookModel.Year
            };
        }
        public static Books ToBooksFromCreateDto(this CreateBooksRequestDto booksDto, int authorId)
        {
            return new Books
            {
                Title = booksDto.Title,
                Genre_id = booksDto.Genre_id,
                Secondary_genre_id = booksDto.Secondary_genre_id,
                Tertiary_genre_id = booksDto.Tertiary_genre_id,
                Language_id = booksDto.Language_id,
                Coverage_id = booksDto.Coverage_id,
                Bookhouse_id = booksDto.Bookhouse_id,
                City_id = booksDto.City_id,
                
                Translator_id = booksDto.Translator_id,
                Translation = booksDto.Translation,
                Pages = booksDto.Pages,
                Year = booksDto.Year
            };
        }
    }
}
