using books.Enitity;
using books.Model;
using Microsoft.EntityFrameworkCore;

namespace books.Repository.book
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<BookModel>> GetAllBooksAsync(string? search = null, string? orderBy = null)
        {


            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.name.Contains(search) || x.author.Contains(search));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(x => x.name);
            }
            return await query.ToListAsync();
        }




        public async Task<BookModel> GetBookByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(BookModel book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(BookModel book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
