using System;
using books.Dto;

namespace books.Model;

public class BookModel
{

    public Guid id { get; set; }

    public string name { get; set; } = string.Empty;

    public string author { get; set; } = string.Empty;

    public string description { get; set; } = string.Empty;
    public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

}
