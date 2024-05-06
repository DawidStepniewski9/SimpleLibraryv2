using Azure;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryv2.Models;
using SimpleLibraryv2.Services;
using SimpleLibraryv2.Validation;

namespace SimpleLibraryv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet ("/GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _service.GetBooks();
            return Ok(result);

            //Ok("test"); ok 200
            //NotFound() 404
            //Error() 500
            //NoContent 203

        }

        [HttpGet("/GetBook/{bookId}")]
        public async Task<IActionResult> GetBook(long bookId)
        {
            var result = await _service.GetBook(bookId);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> Create(BookDTO bookDTO)
        {
            var validator = new BookDTOValidator();
            var result = validator.Validate(bookDTO);
            if (result.IsValid)
            {
                await _service.Create(bookDTO);
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("/Update/{bookId}")]
        public async Task<IActionResult> Update([FromRoute] long bookId, [FromBody] BookDTO bookDTO)
        {
            await _service.Update(bookId, bookDTO);
            return Ok();
        }

        [HttpDelete("/Delete/{bookId}")]
        public async Task<IActionResult> Delete(long bookId)
        {
            await _service.Delete(bookId);
            return Ok();
        }

        [HttpPatch("/Patch/{id}")]
        public async Task<IActionResult> Patch([FromRoute] long id, [FromBody] string title)
        {
            var updatedBook = await _service.UpdateBook(id, title);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpPut("/Put/{id}")]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] BookModelPut bookModelPut)
        { 
            var updatedBook = await _service.UpdateBook(id, bookModelPut);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }


    }
}
