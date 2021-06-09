using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treat.ToList();
      return View(model);
    }

    public ActionResult Create()
    {

      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treat.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treat
          .Include(treat => treat.JoinFlavorTreat)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treat.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}