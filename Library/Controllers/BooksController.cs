using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    public BooksController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
      if (!ModelState.IsValid)
      {
        return View(book);
      }
      else
      {
        _db.Books.Add(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Book thisBook = _db.Books
      .Include(book => book.JoinEntities)
      .ThenInclude(book => book.Author)
      .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      if (!ModelState.IsValid)
      {
        return View(book);
      }
      else
      {
        _db.Books.Update(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, int authorId)
    {
      #nullable enable
      AuthorBook? joinEntity = _db.AuthorBooks.FirstOrDefault(join => join.AuthorBookId == authorId && join.BookId == book.BookId);
      #nullable disable
      if (joinEntity == null && authorId != 0)
      {
        _db.AuthorBooks.Add(new AuthorBook() { AuthorId = authorId, BookId = book.BookId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = book.BookId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      AuthorBook joinEntry = _db.AuthorBooks.FirstOrDefault(entry => entry.AuthorBookId == joinId);
      _db.AuthorBooks.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult SearchAuthor()
    {
      return View();
    }

    [HttpPost]
    public ActionResult SearchAuthor(Book searchedAuthor)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.Author == searchedAuthor.Author);
      if (thisBook != null)
      {
        return RedirectToAction("Details", new { id = thisBook.BookId });
      }
      else
      {
        return RedirectToAction("NoResults");
      }
    }

    public ActionResult SearchTitle()
    {
      return View();
    }

    [HttpPost]
    public ActionResult SearchTitle(Book searchedTitle)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.Title == searchedTitle.Title);
      if (thisBook != null)
      {
        return RedirectToAction("Details", new { id = thisBook.BookId });
      }
      else
      {
        return RedirectToAction("NoResults");
      }
    }

    public ActionResult NoResults()
    {
      return View();
    }

    public ActionResult Checkout(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Checkout(Book book)
    {
      book.CheckedOut = true;
      _db.Books.Update(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}