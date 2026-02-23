using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookRequestRepository
    {
        Task RequestBookAsync(BookRequest request);
        Task<IEnumerable<BookRequest>> ViewAllRequestedBooksAsync();
        Task<IEnumerable<BookRequest>> ViewAllRequestedBooksByStudentId(int StudentID);  
        Task<BookRequest> GetByIdAsync(int id);
        //Task AssignRejectAsync(BookRequest request);
        Task UpdateBookReqAsync(BookRequest req);
    }
}
