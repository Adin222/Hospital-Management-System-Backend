using Hospital_Management_System.DTO.UserDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.UserMappers
{
    public static class UserMappers
    {
      public static UserFullResponse ToUserFullDto(this User user, string department = "NONE")
        {
            return new UserFullResponse
            {
                UserId = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.role,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                DepartmentName = department,
                City = user.City,
                EmploymentDate = user.EmploymentDate,
                CreatedAt = user.CreatedAt
            };
        }

        public static UserDetailsResponse ToUserDetailDto(this UserDto userDto)
        {
            return new UserDetailsResponse
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CreatedAt = DateTime.UtcNow,
                EmploymentDate = userDto.EmploymentDate,
                PhoneNumber = userDto.PhoneNumber,
                Country = userDto.Country,
                City = userDto.City,
                Role = userDto.Role,
                DateOfBirth = userDto.DateOfBirth
            };
        }
    }
}
