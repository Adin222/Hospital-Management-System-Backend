using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
        }
    }
}
