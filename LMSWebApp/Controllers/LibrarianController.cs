using DataAccessLayer.AppDatabase;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSWebApp.Controllers
{

    public class LibrarianController : Controller
    {
        private readonly IBookRepository _repo;
        private readonly IBookRequestRepository _bookreq;
        public LibrarianController(IBookRepository repo ,IBookRequestRepository bookreq)
        {
            _repo = repo;
            _bookreq = bookreq; 
        }


        [HttpGet]
        public async Task<IActionResult> GetBookByID(int Id)
        {

            if (Id <= 0)
            {
                return BadRequest(new { message = "Book ID must be greater than zero." });
            }

            try
            {
                // Rule 2: Find the book
                var book = await _repo.GetByIdAsync(Id);

                if (book == null)
                {
                    return NotFound(new { message = "Book not found with the given ID." });
                }
                return View(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the book.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult AddBooks()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(Book book)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repo.AddAsync(book);
                TempData["SuccessMessage"] = "";
                return RedirectToAction("GetAllBooks", "Librarian");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Server error occurred." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _repo.GetAllBooksAsync();

                if (books == null)
                {
                    return NotFound(new
                    {
                        message = "No books found in the library."
                    });
                }

                return View(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Failed to retrieve books from the database.",
                    error = ex.Message
                });
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            return View(await _repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                await _repo.UpdateAsync(book);
                TempData["SuccessMessage"] = "";
                return RedirectToAction("GetAllBooks", "Librarian");
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The book could not be updated due to a concurrency conflict. Please reload and try again." });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while updating the book." });
            }
        }

        public async Task<IActionResult> GetAllReqBooks() {
            return View(await _bookreq.ViewAllRequestedBooksAsync());
        }


        [HttpGet]
        public async Task<IActionResult> AssignRejBook(int id)
        {
            return View(await _bookreq.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> AssignRejBook(BookRequest bookRequest)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var book = await _repo.GetByIdAsync(bookRequest.BookId);
                if (book == null)
                    throw new ArgumentException("Book not found.");
                if (bookRequest.RequestStatus== "Approved")
                {
                    // Update book status & copies
                    book.AvailableCopies -= 1;
                  
                }
               
                if (bookRequest.RequestStatus == "Returned")
                {
                    book.AvailableCopies += 1;
                }


                await _repo.UpdateAsync(book);
                await _bookreq.UpdateBookReqAsync(bookRequest);
                TempData["SuccessMessage"] = "";
                return RedirectToAction("GetAllBooks", "Librarian");
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The book could not be updated due to a concurrency conflict. Please reload and try again." });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while updating the book." });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> SearchBooks(string keyword)
        //{
        //    var result = await _repo.SearchAsync(keyword);
        //    return View(result);
        //}
    }
}
