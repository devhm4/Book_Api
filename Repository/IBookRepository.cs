using System;
using books.Model;

namespace books.Repository;

public interface IBookRepository
{
    Task<IEnumerable<BookModel>> GetAllBooksAsync();
    Task<BookModel> GetBookByIdAsync(Guid id);
    Task AddBookAsync(BookModel book);
    Task UpdateBookAsync(BookModel book);
    Task DeleteBookAsync(Guid id);
}

