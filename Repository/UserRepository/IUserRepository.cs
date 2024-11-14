using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<bool> UserExistsAsync(string email);
        Task<int> GetRoleIdByNameAsync(string roleName);
        Task AddDoctorAsync(Doctor doctor);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task DeleteUserAsync(User user);
        Task<User> GetUserByID(int id);
        Task UpdateUser(User user);
        Task<int> GetDepartmentIdByName(string departmentName);
        Task AddDoctorDepartment(Doctor_Department dep);
        Task<Doctor> GetDoctorById(int id);
        Task UpdateDoctor(Doctor doctor);
        Task<string> GetDepartmentByDoctorId(int id);
        Task<string> GetDoctorNameByDoctorId(int id);
        Task<string> GetUserNameById(int id);
        Task<Doctor> DoctorExists(int id);
        Task<int> ReceptionistExists(int id);
    }
}
