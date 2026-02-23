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
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<List<Book>> GetBooksByStudentIdAsync(int studentId)
        {
            return await _context.BookRequests
                .Where(br => br.StudentID == studentId)
                .Include(br => br.AssignedBook)
                .Select(br => br.AssignedBook!)
                .ToListAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task<Book> GetByIdAsync(int id) =>
             await _context.Books.FindAsync(id);

        //public async Task<IEnumerable<Book>> SearchAsync(string Keyword)
        //{
        //    return await _context.Books
        //         .Where(b => b.Title.Contains(Keyword) ||
        //                    b.Author.Contains(Keyword) ||
        //                    b.Category.Contains(Keyword))
        //        .ToListAsync();
        //}  
    }
}