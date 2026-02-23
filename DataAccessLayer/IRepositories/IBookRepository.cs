using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book books);

        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task UpdateAsync(Book book);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetBooksByStudentIdAsync(int studentId);

        //Task<IEnumerable<Book>> SearchAsync(string Keyword);
    }
}
