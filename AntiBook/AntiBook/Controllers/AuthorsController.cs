using AntiBook.Dtos.Authors;
using AntiBook.Dtos.Books;
using AntiBook.Helpers;
using AntiBook.Interfaces;
using AntiBook.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AntiBook.Controllers
{
    [Route("AntiBook/Authors")]
    [ApiController]
    public class AuthorsController:ControllerBase
    {
        private readonly IAuthorsRepository _authorsRepo;
        public AuthorsController(IAuthorsRepository authorsRepo)
        {
            _authorsRepo = authorsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authors = await _authorsRepo.GetAllAsync(query);
            var authorsDto = authors.Select(s => s.ToAuthorsDto());
            return Ok(authorsDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var authors = await _authorsRepo.GetByIdAsync(id);
            if (authors == null)
            {
                return NotFound();
            }
            return Ok(authors.ToAuthorsDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorsDto authorsDto)
        {
            var authorsModel = authorsDto.ToAuthorsFromCreateDto();
            await _authorsRepo.CreateAsync(authorsModel);
            return CreatedAtAction(nameof(GetById), new { id = authorsModel.Id }, authorsModel.ToAuthorsDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorsDto updateDto)
        {
            var authorModel = await _authorsRepo.UpdateAsync(id, updateDto);
            if (authorModel == null)
            {
                return NotFound();
            }

            return Ok(authorModel.ToAuthorsDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var authorModel = await _authorsRepo.DeleteAsync(id);
            if (authorModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
