using Hospital_Management_System.DTO;
using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new KeyNotFoundException("User doesn't exist");

            return user;
        }
        public async Task<string> GetRoleByID(int roleId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.RoleID == roleId) ?? throw new KeyNotFoundException("Role doesn't exist");
            return role.role;
        }
    }
}
