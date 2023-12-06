using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
  public class HomeController : Controller
  {
    private readonly LibraryContext _db;
    public HomeController(LibraryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Book[] books = _db.Books.ToArray();
      Author[] authors = _db.Authors.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("books", books);
      model.Add("authors", authors);
      return View(model);
    }

  }
}