using System;
using books.Model;

namespace books.Dto;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<BookModel> Books { get; set; } = new List<BookModel>();

}