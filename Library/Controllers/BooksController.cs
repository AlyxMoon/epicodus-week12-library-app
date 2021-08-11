using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using Library.Models;
using Library.Models.Database;

namespace Library.Controllers
{
    [Route("/books")]
    public class BooksController : Controller
    {
      private readonly DatabaseContext _db;

      public BooksController(DatabaseContext db)
      {
        _db = db;
      }

      [HttpGet]
      public ActionResult Index()
      {
        List<Book> model = _db.Books.ToList();
        return View(model);
      }
    }
}