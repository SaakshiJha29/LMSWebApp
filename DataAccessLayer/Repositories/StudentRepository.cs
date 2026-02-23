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
    public class StudentRepository : IStudentRepository
    {
        private readonly BookDbContext _context;
        public StudentRepository(BookDbContext context)
        {
            _context = context;
        }
        public async Task<Students> RegisterAsync(Students student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<bool> AuthenticateByRollNoAsync(string RollNo)
        {
            return await _context.Students
            .AnyAsync(s => s.RollNo == RollNo);   // using .Any()
        }
        public async Task<int?> GetStudentIdByRollNoAsync(string rollNo)
        {
            return await _context.Students
                .Where(s => s.RollNo == rollNo)
                .Select(s => (int?)s.StudentID)
                .FirstOrDefaultAsync();
        }
    }
}
