using Microsoft.AspNetCore.Mvc;
using SimpleLibraryv2.Models;
using SimpleLibraryv2.Services;

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
            await _service.Create(bookDTO);
            return Ok();
        }

        //[HttpPost("/Update")]
        //public async Task<IActionResult> Update(Book book)
        //{ 
        //    await _service.Update(book);
        //    return Ok();
        //}

        [HttpPost("/Delete/{bookId}")]
        public async Task<IActionResult> Delete(long bookId)
        {
            await _service.Delete(bookId);
            return Ok();
        }

    }
}
