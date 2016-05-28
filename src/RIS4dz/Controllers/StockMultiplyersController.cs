using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RIS4dz.Models;
using System.Collections.Generic;

namespace RIS4dz.Controllers
{
    public class StockMultiplyersController : Controller
    {
        private ApplicationDbContext _context;

        public StockMultiplyersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StockMultiplyers
        public IActionResult Index()
        {
            var applicationDbContext = _context.StockMultiplyer.Include(s => s.Fund).Include(s => s.Stock);
            return View(applicationDbContext.ToList());
        }

        // GET: StockMultiplyers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockMultiplyer stockMultiplyer = _context.StockMultiplyer.Include(s => s.Stock).Include(s => s.Fund).Single(m => m.ID == id);
            if (stockMultiplyer == null)
            {
                return HttpNotFound();
            }

            return View(stockMultiplyer);
        }

        // GET: StockMultiplyers/Create
        public IActionResult Create()
        {
            ViewData["FundID"] = new SelectList(_context.Fund, "ID", "Fund");
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock");
            return View();
        }

        // GET: StockMultiplyers/Create
        public IActionResult CreateWithFundID(int id)
        {
            IEnumerable<SelectListItem> funds = _context.Fund.Where(s => s.ID == id).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            ViewBag.Funds = funds;

            IEnumerable<SelectListItem> stocks = _context.Stock.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            ViewBag.Stocks = stocks;

            return View("Create");
        }

        // POST: StockMultiplyers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StockMultiplyer stockMultiplyer)
        {
            if (ModelState.IsValid)
            {
                _context.StockMultiplyer.Add(stockMultiplyer);
                _context.SaveChanges();
                return RedirectToAction("Details", "Funds", new { id = stockMultiplyer.FundID });
            }
            ViewData["FundID"] = new SelectList(_context.Fund, "ID", "Fund", stockMultiplyer.FundID);
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockMultiplyer.StockID);

            return View(stockMultiplyer);
        }

        // GET: StockMultiplyers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockMultiplyer stockMultiplyer = _context.StockMultiplyer.Include(s => s.Stock).Include(s => s.Fund).Single(m => m.ID == id);
            if (stockMultiplyer == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SelectListItem> funds = _context.Fund.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            ViewBag.Funds = funds;

            IEnumerable<SelectListItem> stocks = _context.Stock.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            ViewBag.Stocks = stocks;

            return View(stockMultiplyer);
        }

        // POST: StockMultiplyers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StockMultiplyer stockMultiplyer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(stockMultiplyer);
                _context.SaveChanges();
                return RedirectToAction("Details", "Funds", new { id = stockMultiplyer.FundID });
            }
            ViewData["FundID"] = new SelectList(_context.Fund, "ID", "Fund", stockMultiplyer.FundID);
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockMultiplyer.StockID);

            return View(stockMultiplyer);
        }

        // GET: StockMultiplyers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockMultiplyer stockMultiplyer = _context.StockMultiplyer.Include(s => s.Stock).Include(s => s.Fund).Single(m => m.ID == id);
            if (stockMultiplyer == null)
            {
                return HttpNotFound();
            }

            return View(stockMultiplyer);
        }

        // POST: StockMultiplyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            StockMultiplyer stockMultiplyer = _context.StockMultiplyer.Single(m => m.ID == id);
            _context.StockMultiplyer.Remove(stockMultiplyer);
            _context.SaveChanges();
            return RedirectToAction("Details", "Funds", new { id = stockMultiplyer.FundID });
        }
    }
}
