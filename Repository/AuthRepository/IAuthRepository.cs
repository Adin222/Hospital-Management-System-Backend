using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<string> GetRoleByID(int roleId);
    }
}
