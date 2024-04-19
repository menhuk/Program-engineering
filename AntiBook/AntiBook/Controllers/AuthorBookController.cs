using AntiBook.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AntiBook.Controllers
{
    [Route("AntiBook/AuthorBook")]
    [ApiController]
    public class AuthorBookController:ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorBookController(IBooksRepository booksRepository,IAuthorsRepository authorsRepository) 
        {
            _booksRepository = booksRepository;
            _authorsRepository = authorsRepository;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAuthorBook()
        //{
        //    var author = await _authorsRepository.GetAllAsync();
        //}
    }
}
