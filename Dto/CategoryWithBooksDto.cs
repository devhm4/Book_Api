using System;

namespace books.Dto;

public class CategoryWithBooksDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BookDto> Books { get; set; } = new List<BookDto>();
}
