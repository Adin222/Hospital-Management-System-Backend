using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hospital_Management_System.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<int> GetRoleIdByNameAsync(string roleName)
        {
            return await _context.Roles
                .Where(r => r.role == roleName)
                .Select(r => r.RoleID)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id) ?? throw new KeyNotFoundException("Role doesn't exist");
            return role.role;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return users;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException("User doesn't exist");
            return user;
        }
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserByID(int id)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserID == id) ?? throw new KeyNotFoundException("User doesn't exist");
            return user;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetDepartmentIdByName(string departmentName)
        {
            int id = await _context.Departments
                .Where(d => d.DepartmentName == departmentName)
                .Select(u => u.DepartmentID)
                .FirstOrDefaultAsync();
            return id;
        }

        public async Task AddDoctorDepartment(Doctor_Department dep)
        {
            _context.DoctorDepartments.Add(dep);
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.UserID == id);
            if (doctor == null) throw new KeyNotFoundException("Doctor doesn't exist");
            return doctor;
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetDepartmentByDoctorId(int id)
        {
            int drId = await _context.Doctors.Where(u => u.UserID == id).Select(dp => dp.DoctorID).FirstOrDefaultAsync();

            var DPid = await _context.DoctorDepartments
                .Where(d => d.DoctorID == drId)
                .Select(dp => dp.DepartmentID)
                .FirstOrDefaultAsync();

            var department = await _context.Departments
                .Where(d => d.DepartmentID == DPid)
                .Select(dp => dp.DepartmentName)
                .FirstOrDefaultAsync();
            if (department == null) throw new KeyNotFoundException("There is no such department");
            return department;
        }

        public async Task<string> GetDoctorNameByDoctorId(int id)
        {
            var name = await _context.Doctors
                .Where(d => d.DoctorID == id)
                .Select(d => d.FirstName)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Doctor doesn't exist");
            
            return name;
        }

        public async Task<string> GetUserNameById(int id)
        {
            var name = await _context.Users
               .Where(p => p.UserID == id)
               .Select(p => p.FirstName)
               .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User doesn't exist");
            return name;
        }

        public async Task<Doctor> DoctorExists(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id) ?? throw new KeyNotFoundException("Docotor doesn't exist");
            return doctor;
        }

        public async Task<int> ReceptionistExists(int id)
        {
            var receptionist = await _context.Users
                .Where(u => u.UserID == id)
                .Select(u => u.RoleID)
                .FirstOrDefaultAsync();
            return receptionist;
        }
    }
}
