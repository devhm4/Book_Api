using books.Mapper;
using books.Model;
using books.Repository;
using books.Repository.book;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string search = null)
        {
            var books = await _bookRepository.GetAllBooksAsync(query: search);
            var bookDto = books.Select(s => s.toBookDto()).ToList();


            return Ok(bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = new BookModel
            {
                name = book.name,
                author = book.author,
                description = book.description
            };

            await _bookRepository.AddBookAsync(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.name = book.name;
            existingBook.author = book.author;
            existingBook.description = book.description;

            await _bookRepository.UpdateBookAsync(existingBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
