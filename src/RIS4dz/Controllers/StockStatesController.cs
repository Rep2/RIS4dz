using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RIS4dz.Models;
using System.Data.Common;
using System.Collections.Generic;
using System;

namespace RIS4dz.Controllers
{
    public class StockStatesController : Controller
    {
        private ApplicationDbContext _context;

        public StockStatesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StockStates
        public IActionResult Index()
        {
            var applicationDbContext = _context.StockState.Include(s => s.Stock);
            return View(applicationDbContext.ToList());
        }

        // GET: StockStates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockState stockState = _context.StockState.Include(s => s.Stock).Single(m => m.ID == id);
            if (stockState == null)
            {
                return HttpNotFound();
            }

            return View(stockState);
        }

        // GET: StockStates/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Stock.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            ViewBag.Stocks = items;

            return View();
        }

        // GET: StockStates/Create
        public IActionResult CreateWithID(int id)
        {
            IEnumerable<SelectListItem> items = _context.Stock.Where(s => s.ID == id).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            ViewBag.Stocks = items;

            return View("Create");
        }

        // POST: StockStates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StockState stockState)
        {
            stockState.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.StockState.Add(stockState);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockState.StockID);
            return View(stockState);
        }

        // GET: StockStates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockState stockState = _context.StockState.Include(s => s.Stock).Single(m => m.ID == id);
            if (stockState == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SelectListItem> items = _context.Stock.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
        
            ViewBag.Stocks = items;

            return View(stockState);
        }

        // POST: StockStates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StockState stockState)
        {
            if (ModelState.IsValid)
            {
                _context.Update(stockState);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockState.StockID);
            return View(stockState);
        }

        // GET: StockStates/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockState stockState = _context.StockState.Include(s => s.Stock).Single(m => m.ID == id);
            if (stockState == null)
            {
                return HttpNotFound();
            }

            return View(stockState);
        }

        // POST: StockStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            StockState stockState = _context.StockState.Single(m => m.ID == id);
            _context.StockState.Remove(stockState);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
