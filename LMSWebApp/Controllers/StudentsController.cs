using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMSWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repo;
        public readonly IBookRepository _ibook;
        private readonly IBookRequestRepository _bookreq;
        int Studentid;
        public StudentsController(IStudentRepository repo,
            IBookRequestRepository bookreq,
            IBookRepository ibook)
        {
            _repo = repo;
            _bookreq = bookreq;
            _ibook = ibook;
        }


        [HttpGet]
        public IActionResult RegisterStudents()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudents(Students dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _repo.RegisterAsync(dto);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Registration successful! Redirecting to login...";
                    return RedirectToAction("Login", "Students");
                }
                else
                {
                    TempData["SuccessMessage"] = "Something went wrong.";
                    return View();
                }

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
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(string rollno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (rollno == "admin")
                {
                    return RedirectToAction("GetAllBooks", "Librarian");
                }
                else
                {
                    var student = await _repo.AuthenticateByRollNoAsync(rollno);
                    if (student)
                    {
                        Studentid = (await _repo.GetStudentIdByRollNoAsync(rollno)) ?? 0;
                        HttpContext.Session.SetString("StudentRollNo", Studentid.ToString());
                        TempData["SuccessMessage"] = "";
                        return RedirectToAction("StudentHomepage", "Students");
                    }
                    else
                    {
                        return NotFound(new { Message = "Invalid Credentials" });
                    }
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch
            {
                return StatusCode(500, new { message = "Server error while logging in." });
            }
        }

        public IActionResult StudentHomepage()
        {
            return View();
        }


        public IActionResult Logout()
        {
            return RedirectToAction("login");
        }


        [HttpGet]

        public async Task<IActionResult> RequestBook()
        {
            ViewBag.booklist = new SelectList(await _ibook.GetAllBooksAsync(), "BookId", "Title"); // getting id ,username ,email , password

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestBook(BookRequest bookRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Books = new BookRequest
                {
                    BookId = bookRequest.BookId,
                    StudentID = Convert.ToInt32(HttpContext.Session.GetString("StudentRollNo").ToString()),
                    FromDate = bookRequest.FromDate,
                    ToDate = bookRequest.ToDate,
                    RequestStatus = "Pending"
                };
                await _bookreq.RequestBookAsync(Books);
                TempData["SuccessMessage"] = "Book Requested successfully...";
                return RedirectToAction("GetBooksByStudentId", "Students");
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
        public async Task<IActionResult> GetBooksByStudentId()
        {
            int studentid =Convert.ToInt32( HttpContext.Session.GetString("StudentRollNo").ToString());
            var books = await _bookreq.ViewAllRequestedBooksByStudentId(studentid);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _ibook.GetAllBooksAsync();

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
    }
}
