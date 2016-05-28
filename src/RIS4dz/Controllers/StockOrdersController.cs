using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RIS4dz.Models;
using System.Collections.Generic;
using System;

namespace RIS4dz.Controllers
{
    public class StockOrdersController : Controller
    {
        private ApplicationDbContext _context;

        public StockOrdersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StockOrders
        public IActionResult Index()
        {
            var applicationDbContext = _context.StockOrder.Include(s => s.Stock);
            ViewBag.States = _context.StockState.ToList();

            return View(applicationDbContext.ToList());
        }

        // GET: StockOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockOrder stockOrder = _context.StockOrder.Single(m => m.ID == id);
            if (stockOrder == null)
            {
                return HttpNotFound();
            }

            return View(stockOrder);
        }

        // GET: StockOrders/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Stock.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            ViewBag.Stocks = items;

            List<Stock> stocksFull = _context.Stock.ToList();

            ViewBag.StocksFull = stocksFull;

            return View();
        }

        // GET: StockOrders/Create
        public IActionResult CreateBuy(int id)
        {
            ViewBag.Stock = _context.Stock.Include(s => s.States).Single(c => c.ID == id);

            return View("Create");
        }

        // POST: StockOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StockOrder stockOrder)
        {
            stockOrder.DateOrdered = DateTime.Now;
            var stock = _context.Stock.Include(s => s.States).Single(c => c.ID == stockOrder.StockID);
            var state = stock.States.OrderByDescending(s => s.Date).FirstOrDefault();

            if(state != null)
            {
                stockOrder.ShareValueAtOrder = state.BuyRate;
            }

            stockOrder.TransactionFee = 0.001 * stockOrder.ShareValueAtOrder * stockOrder.NumberOfShares;
            stockOrder.TotalValueAtOrder = stockOrder.ShareValueAtOrder * stockOrder.NumberOfShares;

            if (ModelState.IsValid)
            {
                _context.StockOrder.Add(stockOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockOrder.StockID);
            return View(stockOrder);
        }

        // GET: StockOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockOrder stockOrder = _context.StockOrder.Single(m => m.ID == id);
            if (stockOrder == null)
            {
                return HttpNotFound();
            }
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockOrder.StockID);
            return View(stockOrder);
        }

        // POST: StockOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StockOrder stockOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Update(stockOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StockID"] = new SelectList(_context.Stock, "ID", "Stock", stockOrder.StockID);
            return View(stockOrder);
        }

        // GET: StockOrders/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StockOrder stockOrder = _context.StockOrder.Single(m => m.ID == id);
            if (stockOrder == null)
            {
                return HttpNotFound();
            }

            return View(stockOrder);
        }

        // POST: StockOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            StockOrder stockOrder = _context.StockOrder.Single(m => m.ID == id);
            _context.StockOrder.Remove(stockOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
