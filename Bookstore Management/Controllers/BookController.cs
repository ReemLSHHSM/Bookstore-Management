using Bookstore_Management.Data;
using Bookstore_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bookstore_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        // GET: View Create Form
        public IActionResult Create()
        {
            var model = new Book(); // Create a new empty model to pass to the view
            return View(model);
        }

        // POST: Submit Create Form
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book); // Return the same view with the book model if validation fails
            }

            _context.books.Add(book); // Add the book to the database
            await _context.SaveChangesAsync(); // Save the changes asynchronously

            return RedirectToAction(nameof(Index)); // Redirect to the Index page after creation
        }

        // GET: View Book Details
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            return View(book); // Return the book details view
        }

        // GET: View All Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.books.ToListAsync(); // Get all books asynchronously
            if (books == null || !books.Any())
            {
                return NotFound("No Books Stored");
            }

            return View(books); // Return the view with the list of books
        }

        // GET: Edit Book by ID
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            return View(book); // Return the Edit view with the book model
        }

        // POST: Submit Edit Form
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book); // Return the same view if validation fails
            }

            var existingBook = await _context.books.FirstOrDefaultAsync(x => x.Id == book.Id);

            if (existingBook == null)
            {
                return NotFound("Book Not Found");
            }

            // Update existing book details
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.Title = book.Title;
            existingBook.Genre = book.Genre;

            await _context.SaveChangesAsync(); // Save changes asynchronously

            return RedirectToAction(nameof(Index)); // Redirect to the Index page after editing
        }

        // GET: Confirm Delete Book by ID
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            return View(book); // Return the delete confirmation view
        }

        // POST: Delete Book
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            _context.books.Remove(book); // Remove the book from the context
            await _context.SaveChangesAsync(); // Save changes asynchronously

            return RedirectToAction(nameof(Index)); // Redirect to the Index page after deletion
        }
    }
}
