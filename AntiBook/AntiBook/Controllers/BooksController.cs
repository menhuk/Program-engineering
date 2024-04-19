using AntiBook.Data;
using AntiBook.Dtos.Books;
using AntiBook.Interfaces;
using AntiBook.Mappers;
using AntiBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AntiBook.Data.ApplicationDBContext;
namespace AntiBook.Controllers
{
    [Route("AntiBook/Books")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        private readonly IBooksRepository _booksRepo;
        private readonly IAuthorsRepository _authorsRepo;
        public BooksControllers(IBooksRepository booksRepo, IAuthorsRepository authorRepo)
        {
            _booksRepo = booksRepo;
            _authorsRepo = authorRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksRepo.GetAllAsync();
            var booksDto = books.Select(s => s.ToBooksDto());
            return Ok(booksDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var books = await _booksRepo.GetByIdAsync(id);
            if (books == null)
            {
                return NotFound();

            }
            return Ok(books.ToBooksDto());
        }
        [HttpPost("{authorId:int}")]
        public async Task<IActionResult> Create([FromRoute]int authorId, [FromBody] CreateBooksRequestDto bookDto)
        {
            if(!await _authorsRepo.AuthorExists(authorId))
            {
                return BadRequest("Author does not exist");
            }
            var bookModel = bookDto.ToBooksFromCreateDto(authorId);
            await _booksRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById), new {id =  bookModel},bookModel.ToBooksDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBooksRequestDto updateDto)
        {
            var bookModel = await _booksRepo.UpdateAsync(id,updateDto);
            if (bookModel == null)
            {
                return NotFound();
            }
            
            return Ok(bookModel.ToBooksDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel = await _booksRepo.DeleteAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
