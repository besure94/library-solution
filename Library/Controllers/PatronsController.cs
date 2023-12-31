using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;
    public PatronsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patrons.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patron patron)
    {
      if (!ModelState.IsValid)
      {
        return View(patron);
      }
      else
      {
        _db.Patrons.Add(patron);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Patron thisPatron = _db.Patrons
      .Include(patron => patron.JoinClasses)
      .ThenInclude(patron => patron.Book)
      .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }
  }
}