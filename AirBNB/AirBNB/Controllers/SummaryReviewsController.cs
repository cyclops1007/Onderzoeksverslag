﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBNB.Models;

namespace AirBNB.Controllers
{
    public class SummaryReviewsController : Controller
    {
        private readonly AirBNBContext _context;

        public SummaryReviewsController(AirBNBContext context)
        {
            _context = context;
        }

        // GET: SummaryReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.SummaryReviews.ToListAsync());
        }

        // GET: SummaryReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryReviews = await _context.SummaryReviews
                .FirstOrDefaultAsync(m => m.SummaryreviewsId == id);
            if (summaryReviews == null)
            {
                return NotFound();
            }

            return View(summaryReviews);
        }

        // GET: SummaryReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SummaryReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SummaryreviewsId,ListingId,Date")] SummaryReviews summaryReviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summaryReviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summaryReviews);
        }

        // GET: SummaryReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryReviews = await _context.SummaryReviews.FindAsync(id);
            if (summaryReviews == null)
            {
                return NotFound();
            }
            return View(summaryReviews);
        }

        // POST: SummaryReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SummaryreviewsId,ListingId,Date")] SummaryReviews summaryReviews)
        {
            if (id != summaryReviews.SummaryreviewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summaryReviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummaryReviewsExists(summaryReviews.SummaryreviewsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(summaryReviews);
        }

        // GET: SummaryReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryReviews = await _context.SummaryReviews
                .FirstOrDefaultAsync(m => m.SummaryreviewsId == id);
            if (summaryReviews == null)
            {
                return NotFound();
            }

            return View(summaryReviews);
        }

        // POST: SummaryReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var summaryReviews = await _context.SummaryReviews.FindAsync(id);
            _context.SummaryReviews.Remove(summaryReviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummaryReviewsExists(int id)
        {
            return _context.SummaryReviews.Any(e => e.SummaryreviewsId == id);
        }
    }
}
