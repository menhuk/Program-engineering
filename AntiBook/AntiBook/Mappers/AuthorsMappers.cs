using AntiBook.Dtos.Authors;
using AntiBook.Dtos.Books;
using AntiBook.Models;

namespace AntiBook.Mappers
{
    public static class AuthorsMappers
    {
        public static AuthorsDto ToAuthorsDto(this Authors authorsModel)
        {
            return new AuthorsDto
            {
                Id = authorsModel.Id,
                Name = authorsModel.Name,
                Surname = authorsModel.Surname,
            };
        }
        public static Authors ToAuthorsFromCreateDto(this CreateAuthorsDto authorDto)
        {
            return new Authors
            {
                Name = authorDto.Name,
                Surname= authorDto.Surname
            };
        }
    }
}
