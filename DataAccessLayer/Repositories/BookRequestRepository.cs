using DataAccessLayer.AppDatabase;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRequestRepository : IBookRequestRepository
    {
        private readonly BookDbContext _context;
        public BookRequestRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task RequestBookAsync(BookRequest req)
        {
            var bookReq = new BookRequest
            {
                StudentID = req.StudentID,
                BookId = req.BookId,
                FromDate = req.FromDate,
                ToDate = req.ToDate,
                RequestStatus = "Pending"
            };
            _context.BookRequests.Add(bookReq);
            await _context.SaveChangesAsync();
        }
        public async Task<BookRequest> GetByIdAsync(int id) =>
             await _context.BookRequests.FindAsync(id);
      
        public async Task<IEnumerable<BookRequest>> ViewAllRequestedBooksAsync()
        {
            return await _context.BookRequests
    .Include(br => br.AssignedStudents)
    .Include(br => br.AssignedBook)
    .ToListAsync();
        }
        public async Task<IEnumerable<BookRequest>> ViewAllRequestedBooksByStudentId(int StudentID)
        {
            return await _context.BookRequests
                .Where(br => br.StudentID == StudentID)
    .Include(br => br.AssignedStudents)
    .Include(br => br.AssignedBook)
    .ToListAsync();
        }
        public async Task UpdateBookReqAsync(BookRequest req)
        {
            // 1. Find the existing BookRequest by Id
            var bookReq = await _context.BookRequests
                .FirstOrDefaultAsync(b => b.Id == req.Id);

            if (bookReq == null)
                throw new KeyNotFoundException($"BookRequest with Id {req.Id} not found.");

            // 2. Update the fields
            // Only update fields you want to allow changes for
            // Typically, FK fields (StudentID, BookId) might not be updated
            bookReq.FromDate = req.FromDate;
            bookReq.ToDate = req.ToDate;
            bookReq.RequestStatus = req.RequestStatus;

           

            // Optional: update FKs if needed
            // bookReq.StudentID = req.StudentID;
            // bookReq.BookId = req.BookId;

            // 3. Save changes
            await _context.SaveChangesAsync();
        }

       /* public async Task AssignRejectAsync(BookRequest request)
        {
            _context.BookRequests.Update(request);
            await _context.SaveChangesAsync();
        }
       */

    }
}
