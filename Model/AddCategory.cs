using System;
using System.ComponentModel.DataAnnotations;

namespace books.Model;

public class AddCategory
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(20, ErrorMessage = "Name is too long")]
    [MinLength(3, ErrorMessage = "Name is too short")]
    public string name { get; set; }

}
