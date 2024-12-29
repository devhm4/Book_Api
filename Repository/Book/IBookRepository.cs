using System;
using books.Model;

namespace books.Repository.book;

public interface IBookRepository
{
    Task<IEnumerable<BookModel>> GetAllBooksAsync(string? search = null, string? orderBy = null);
    Task<BookModel> GetBookByIdAsync(Guid id);
    Task AddBookAsync(BookModel book);
    Task UpdateBookAsync(BookModel book);
    Task DeleteBookAsync(Guid id);
}

