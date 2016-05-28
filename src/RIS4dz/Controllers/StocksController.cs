using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RIS4dz.Models;

namespace RIS4dz.Controllers
{
    public class StocksController : Controller
    {
        private ApplicationDbContext _context;

        public StocksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stocks
        public IActionResult Index()
        {
            return View(_context.Stock.Include(s => s.States).ToList());
        }

        // GET: Stocks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Stock stock = _context.Stock.Include(s => s.States).Single(m => m.ID == id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Stock.Add(stock);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Stock stock = _context.Stock.Include(s => s.States).Single(m => m.ID == id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Update(stock);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // GET: Stocks/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Stock stock = _context.Stock.Include(s => s.States).Single(m => m.ID == id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Stock stock = _context.Stock.Single(m => m.ID == id);
            _context.Stock.Remove(stock);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
