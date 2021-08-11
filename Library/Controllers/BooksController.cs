using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Library.Models;
using Library.Models.Database;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly DatabaseContext _db;

    public BooksController(DatabaseContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> model = _db.Books.ToList();
      return View(model);
    }

    public ActionResult Details (int id)
    {
      Book book = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(book);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Book book = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(book);
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
      Book book = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(book);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}