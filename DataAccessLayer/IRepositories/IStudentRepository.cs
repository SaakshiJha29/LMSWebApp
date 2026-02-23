using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentRepository
    {
     	Task<Students> RegisterAsync(Students student);
        Task<bool> AuthenticateByRollNoAsync(string RollNo);
        Task<int?> GetStudentIdByRollNoAsync(string rollNo);
      
    }
}
