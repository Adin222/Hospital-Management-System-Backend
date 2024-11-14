using Hospital_Management_System.DTO.UserDTOs;

namespace Hospital_Management_System.Services.UserServices
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserDto userDto);
        Task<IEnumerable<UserResponse>> GetUsersAsync();
        Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<UserResponse> GetUserById(int id);
        Task DeleteUserAsync(int id);
    }
}
