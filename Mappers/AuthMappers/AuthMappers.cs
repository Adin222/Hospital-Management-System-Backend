using Hospital_Management_System.DTO.AuthDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.AuthMappers
{
    public static class AuthMappers
    {
        public static LoggedUserDto ToLoggedUserDto(this User user, string role)
        {
            return new LoggedUserDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = role
            };
        }
    }
}
