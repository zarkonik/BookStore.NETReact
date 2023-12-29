using BookStoreZN.Services.BookService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreZN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        [EnableCors]
        public async Task<ActionResult<List<Book>>> GetBooks() {
            return await _bookService.GetBooks();
        }

        [HttpGet("{id}")]
        [EnableCors]
        public async Task<ActionResult<Book>> GetSingleBook(int id)
        {
            var result = await _bookService.GetSingleBook(id);
            if(result is null)
                return NotFound("Book not found");

            return Ok(result);
        }

        [HttpPost]
        [EnableCors]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            var result = await _bookService.AddBook(book);
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        [EnableCors]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book request)
        {
            var result = await _bookService.UpdateBook(id, request);
            if(result is null)
            {
                return NotFound("Book not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [EnableCors]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if(result == null)
            {
                return NotFound("Book not found");
            }
            return Ok(result);
        }
    }
}
