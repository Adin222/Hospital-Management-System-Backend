using Hospital_Management_System.DTO.UserDTOs;

namespace Hospital_Management_System.Services.UserServices
{
    public interface IUserService
    {
        Task<UserDetailsResponse> CreateUserAsync(UserDto userDto);
        Task<IEnumerable<UserFullResponse>> GetUsersAsync();
        Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<UserFullResponse> GetUserById(int id);
        Task DeleteUserAsync(int id);
    }
}
