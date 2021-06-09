// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using PierresTreats.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;
// using System.Security.Claims;

// namespace PierresTreats.Controllers
// {
//   [Authorize]
//   public class PatronsController : Controller
//   {
//     private readonly PierresTreatsContext _db;
//     private readonly UserManager<ApplicationUser> _userManager;

//     public PatronsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
//     {
//       _userManager = userManager;
//       _db = db;
//     }

//     public async Task<ActionResult> Index()
//     {
//       var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       var currentUser = await _userManager.FindByIdAsync(userId);
//       // var userPatrons = _db.Patron.Where(entry => entry.User.Id == currentUser.Id).ToList();
//       return View(userPatrons);
//     }

//     public ActionResult Create()
//     {
//       ViewBag.BookId = new SelectList(_db.Book, "BookId", "Name");
//       return View();
//     }

//     [HttpPost]
//     public async Task<ActionResult> Create(Patron patron, int BookId)
//     {
//       var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       var currentUser = await _userManager.FindByIdAsync(userId);
//       patron.User = currentUser;
//       _db.Patron.Add(patron);
//       _db.SaveChanges();
//       if (BookId != 0)
//       {
//         _db.Checkout.Add(new Checkout() { BookId = BookId, PatronId = patron.PatronId });
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       var thisPatron = _db.Patron
//           .Include(patron => patron.JoinBookPatron)
//           .ThenInclude(join => join.Book)
//           .FirstOrDefault(patron => patron.PatronId == id);
//       return View(thisPatron);
//     }

//     public ActionResult Edit(int id)
//     {
//       var thisPatron = _db.Patron.FirstOrDefault(patron => patron.PatronId == id);
//       ViewBag.BookId = new SelectList(_db.Book, "BookId", "Name");
//       return View(thisPatron);
//     }

//     [HttpPost]
//     public ActionResult Edit(Patron patron, int BookId)
//     {
//       if (BookId != 0)
//       {
//         _db.Checkout.Add(new Checkout() { BookId = BookId, PatronId = patron.PatronId });
//       }
//       _db.Entry(patron).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult AddBook(int id)
//     {
//       var thisPatron = _db.Patron.FirstOrDefault(patron => patron.PatronId == id);
//       ViewBag.BookId = new SelectList(_db.Book, "BookId", "Name");
//       return View(thisPatron);
//     }

//     [HttpPost]
//     public ActionResult AddBook(Patron patron, int BookId)
//     {
//       if (BookId != 0)
//       {
//         _db.Checkout.Add(new Checkout() { BookId = BookId, PatronId = patron.PatronId });
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisPatron = _db.Patron.FirstOrDefault(patron => patron.PatronId == id);
//       return View(thisPatron);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisPatron = _db.Patron.FirstOrDefault(patron => patron.PatronId == id);
//       _db.Patron.Remove(thisPatron);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public ActionResult DeleteBook(int joinId)
//     {
//       var joinEntry = _db.Checkout.FirstOrDefault(entry => entry.CheckoutId == joinId);
//       _db.Checkout.Remove(joinEntry);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//   }
// }