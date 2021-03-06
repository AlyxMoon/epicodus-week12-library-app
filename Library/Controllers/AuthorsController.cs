using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using System;

using Library.Models;
using Library.Models.Database;

namespace Library.Controllers
{
  public class AuthorsController : Controller
  {
    private readonly DatabaseContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public AuthorsController(DatabaseContext db)
    {
      _db = db;
      // _userManager = userManager;
    }

    public ActionResult Index()
    {
      List<Author> model = _db.Authors.ToList();
      return View(model);
    }

    public ActionResult Details (int id)
    {
      Author author = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(author);
    }

    // public async Task<ActionResult> Index(string searchString)
    // {
    //   var authors = _db.Authors;
    //   if(!String.IsNullOrEmpty(searchString))
    //   {
    //     authors = authors.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
    //   }
      
    //   return View(await authors.ToListAsync());
    // }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author)
    {
      _db.Authors.Add(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Author selectedAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(selectedAuthor);
    }

    [HttpPost]
    public ActionResult Edit(Author author)
    {
      _db.Entry(author).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Author selectedAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      _db.Authors.Remove(selectedAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Details(int id)
    // {
    //   Author selectedAuthor = _db.Authors
    //     .Include(author => author.JoinEntities)
    //     .ThenInclude(join => join.Book)
    //     .FirstOrDefault(author => author.AuthorId == id);
    //   return View(selectedAuthor);
    // }
  }
}