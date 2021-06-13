using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;


namespace Library.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresTreatsContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(PierresTreatsContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Treat = _db.Treat.ToList();
      ViewBag.Flavor = _db.Flavor.ToList();
      return View();
    }

  }
}