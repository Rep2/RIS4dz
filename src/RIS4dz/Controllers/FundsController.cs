using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RIS4dz.Models;
using System;
using System.Collections.Generic;

namespace RIS4dz.Controllers
{
    public class FundsController : Controller
    {
        private ApplicationDbContext _context;

        public FundsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Funds
        public IActionResult Index()
        {
            return View(_context.Fund.ToList());
        }

        // GET: Funds/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Fund fund = _context.Fund.Include(s => s.Stocks).Single(m => m.ID == id);
            if (fund == null)
            {
                return HttpNotFound();
            }

            List<StockState> states = _context.StockState.ToList();
            ViewBag.States = states;

            List<Stock> stocks = _context.Stock.ToList();
            ViewBag.Stocks = stocks;

            return View(fund);
        }

        // GET: Funds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fund fund)
        {
            fund.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Fund.Add(fund);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fund);
        }

        // GET: Funds/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Fund fund = _context.Fund.Single(m => m.ID == id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            return View(fund);
        }

        // POST: Funds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fund fund)
        {
            if (ModelState.IsValid)
            {
                _context.Update(fund);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fund);
        }

        // GET: Funds/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Fund fund = _context.Fund.Single(m => m.ID == id);
            if (fund == null)
            {
                return HttpNotFound();
            }

            return View(fund);
        }

        // POST: Funds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Fund fund = _context.Fund.Single(m => m.ID == id);
            _context.Fund.Remove(fund);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
