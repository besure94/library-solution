using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }

    [Required(ErrorMessage = "Book must have a title.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Book must have a year.")]
    [Range(1, 2023, ErrorMessage = "Year must be between 1 and 2023.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Book must have a genre.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Book must have a number of pages.")]
    [Range(1, 2023, ErrorMessage = "Year must be between 1 and 2023.")]
    public int Pages { get; set; }

  }
}