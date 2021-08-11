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
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthorsController(UserManager<ApplicationUser> userManager, DatabaseContext db)
    {
      _db = db;
      _userManager = userManager;
    }

    public ActionResult Index()
    {
      List<Author> model = _db.Authors.ToList();
      return View(model);
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

    [HttpPost]
    public ActionResult Create()
    {
      return View();
    }
  }
}