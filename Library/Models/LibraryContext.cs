using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net;
using System.Diagnostics.Eventing.Reader;

namespace Library.Models
{
  public class LibraryContext : DbContext
  {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public LibraryContext(DbContextOptions options) : base(options) { }

  }
}