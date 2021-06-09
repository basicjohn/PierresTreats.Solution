using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class BooksController : Controller
  {
    private readonly PierresTreatsContext _db;

    public BooksController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> model = _db.Book.ToList();
      return View(model);
    }

    public ActionResult Create()
    {

      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
      _db.Book.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Book
          .Include(book => book.JoinAuthorBook)
          .ThenInclude(join => join.Author)
          .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    public ActionResult Edit(int id)
    {
      var thisBook = _db.Book.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Book.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Book.FirstOrDefault(book => book.BookId == id);
      _db.Book.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}