using System;

namespace books.Model;

public class AddBookModel
{


    public Guid id { get; set; }

    public string name { get; set; } = string.Empty;

    public string author { get; set; } = string.Empty;

    public string description { get; set; } = string.Empty;
}
