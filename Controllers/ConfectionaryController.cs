using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ConfectionaryController : Controller
    {
        private readonly MvcMovieContext _context;

        public ConfectionaryController(MvcMovieContext context)
        {
            _context = context;
        }

        // POST: Confectionary Search 
        public async Task<IActionResult> Index(string searchString)
        {
            var confectionaries = _context.ConfectionaryItems;

            if (!String.IsNullOrEmpty(searchString))
            {
                confectionaries.Where(s => s.ProductName!.Contains(searchString));
            }

            var confectionaryViewModel = new ConfectionaryViewModel
            {
                ShopItems = await confectionaries.ToListAsync()
            };

            return View(confectionaryViewModel);
        }



        // GET: Confectionary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confectionary = await _context.ConfectionaryItems
                .FirstOrDefaultAsync(confectionary => confectionary.Id == id);
            if (confectionary == null)
            {
                return NotFound();
            }

            return View(confectionary);
        }

        //GET: Confectionary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confectionary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ProductType,Price")] Confectionary confectionary)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(confectionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confectionary);
        }

        // GET: Confectionary/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confectionary = await _context.ConfectionaryItems.FindAsync(id);
            if (confectionary == null)
            {
                return NotFound();
            }
            return View(confectionary);
        }

        // POST: Confectionary/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductType,Price")] Confectionary confectionary)
        {
            if (id != confectionary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confectionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfectionaryExists(confectionary.Id))
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
            return View(confectionary);
        }

        private bool ConfectionaryExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Confectionary/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confectionary = await _context.ConfectionaryItems
                .FirstOrDefaultAsync(Confectionary => Confectionary.Id == id);
            if (confectionary == null)
            {
                return NotFound();
            }

            return View(confectionary);
        }

        // POST: Confectionary/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confectionary = await _context.ConfectionaryItems.FindAsync(id);
            _context.ConfectionaryItems.Remove(confectionary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
