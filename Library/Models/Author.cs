using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Author
  {
    public int AuthorId { get; set; }

    [Required(ErrorMessage = "Author must have a name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Author must have a biography.")]
    public string Biography { get; set; }
    public List<Book> Books { get; set; }
    public List<AuthorBook> JoinEntities { get; }

  }
}