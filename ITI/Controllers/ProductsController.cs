using ITI.Data;
using ITI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace ITI.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string? search)
        {
            ViewBag.CurrentSearch = search;

           if(string.IsNullOrEmpty(search) == false)
            {
                return View("Index", _context.Products.Where(e => e.Name.Contains(search) || e.Category.Contains(search)).ToList());
            }
            else
            {
                return View("Index", _context.Products.ToList());
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);

            if(product is null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product.createByUserId = User.Identity.Name;
                    product.creationDate = DateTime.Now;

                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating product: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while saving the product.");
                }
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Validation error: {error.ErrorMessage}");
            }

            return View(product);
        }
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            //if(id is null)
            //{
            //    return NotFound();
            //}
            var product = await _context.Products.FindAsync(id);
            if(product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id, Products product)
        {
            if(id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    product.lastUpdate = DateTime.Now;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null)
            //{
            //    return NotFound();
            //}
            var product = await _context.Products.FirstOrDefaultAsync(y => y.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductExists(int productId)
        {
            return _context.Products.Any(z => z.Id == productId);
        }
    }
}
