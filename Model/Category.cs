using System;

namespace books.Model;

public class CategoryModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public List<BookModel> Books { get; set; } = new List<BookModel>();


}
