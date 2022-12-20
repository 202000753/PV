using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESTSBooks.Data;
using ESTSBooks.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ESTSBooks.Controllers
{
    [Authorize(Roles = "Manager")]
    public class BookStoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookStoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookStores
        public async Task<IActionResult> Index()
        {
              return View(await _context.BookStore.ToListAsync());
        }

        // GET: BookStores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BookStore == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore
                .FirstOrDefaultAsync(m => m.BookStoreId == id);
            if (bookStore == null)
            {
                return NotFound();
            }

            return View(bookStore);
        }

        // GET: BookStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookStoreId,Location")] BookStore bookStore)
        {
            if (ModelState.IsValid)
            {
                bookStore.BookStoreId = Guid.NewGuid();
                _context.Add(bookStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore);
        }

        // GET: BookStores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BookStore == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore.FindAsync(id);
            if (bookStore == null)
            {
                return NotFound();
            }
            return View(bookStore);
        }

        // POST: BookStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookStoreId,Location")] BookStore bookStore)
        {
            if (id != bookStore.BookStoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookStoreExists(bookStore.BookStoreId))
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
            return View(bookStore);
        }

        // GET: BookStores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BookStore == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore
                .FirstOrDefaultAsync(m => m.BookStoreId == id);
            if (bookStore == null)
            {
                return NotFound();
            }

            return View(bookStore);
        }

        // POST: BookStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BookStore == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookStore'  is null.");
            }
            var bookStore = await _context.BookStore.FindAsync(id);
            if (bookStore != null)
            {
                _context.BookStore.Remove(bookStore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookStoreExists(Guid id)
        {
          return _context.BookStore.Any(e => e.BookStoreId == id);
        }
    }
}
