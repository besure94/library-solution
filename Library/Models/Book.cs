using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using System;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }

    [Required(ErrorMessage = "Book must have an author.")]
    public string Author { get; set; }

    [Required(ErrorMessage = "Book must have a title.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Book must have a publish year.")]
    [Range(1, 2023, ErrorMessage = "Year must be between 1 and 2023.")]
    public int? Year { get; set; }

    [Required(ErrorMessage = "Book must have a genre.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Book must have a number of pages.")]
    [Range(1, 2023, ErrorMessage = "Year must be between 1 and 2023.")]
    public int? Pages { get; set; }

    [Required(ErrorMessage = "Book must have a number of copies.")]
    [Range(1, 1000, ErrorMessage = "You must enter at least one copy to create a book. Our system can only accommodate 1,000 copies.")]
    public int? Copies { get; set; }
    public List<AuthorBook> JoinEntities { get; }
    public List<Checkout> JoinClasses { get; }

  }
}