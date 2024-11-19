using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.DoctorRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetDoctorIdByUserId(int userId)
        {
            var doctorId = await _context.Doctors
                .Where(dc => dc.UserID == userId)
                .Select(dc => dc.DoctorID)
                .FirstOrDefaultAsync();
            return doctorId;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
           var department = await _context.Departments.AnyAsync(dp => dp.DepartmentName == specialization);

           if (!department) throw new KeyNotFoundException("Department doesn't exist");

           var doctors = await _context.Doctors
          .Where(d => d.DoctorDepartments.Any(dd => dd.Department.DepartmentName == specialization))
          .ToListAsync();

           return doctors;
        }
    }
}
