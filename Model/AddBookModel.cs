using System;
using System.ComponentModel.DataAnnotations;

namespace books.Model;

public class AddBookModel
{

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    [MinLength(3, ErrorMessage = "Name is too short")]
    public string name { get; set; } = string.Empty;
    [Required(ErrorMessage = "author is required")]
    [StringLength(100, ErrorMessage = "author is too long")]
    [MinLength(3, ErrorMessage = "author is too short")]
    public string author { get; set; } = string.Empty;
    [Required(ErrorMessage = "description is required")]
    [StringLength(100, ErrorMessage = "description is too long")]
    [MinLength(3, ErrorMessage = "description is too short")]
    public string description { get; set; } = string.Empty;
    public Guid categoryId { get; set; }
}
