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

        public async Task<Department> GetDepartmentById(int doctorId)
        {
            var departmentId = await GetDepartmentIdByDoctorId(doctorId);

            var department = await _context.Departments.FindAsync(departmentId) ?? throw new KeyNotFoundException("Department doesn't exist");
            return department;
        }

        public async Task<int> GetDepartmentIdByDoctorId(int doctorId)
        {
            var department = await _context.DoctorDepartments
                .Where(dp => dp.DoctorID == doctorId)
                .Select(dp => dp.DepartmentID)
                .FirstOrDefaultAsync();
            return department;
        }
    }
}
