﻿using Hospital_Management_System.Models;
using Hospital_Management_System.Helpers;
using Hospital_Management_System.Repository.UserRepository;
using Hospital_Management_System.DTO.UserDTOs;

namespace Hospital_Management_System.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserDto userDto)
        {
            if (await _userRepository.UserExistsAsync(userDto.Email))
            {
                throw new ApplicationException("User with that email already exists");
            }

            if (userDto.Role == "DOCTOR" && string.IsNullOrEmpty(userDto.DepartmentName)) 
            {
                throw new InvalidOperationException("Doctor must be assigned to the department");
            } 

            var roleId = await _userRepository.GetRoleIdByNameAsync(userDto.Role);
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordHash = _passwordHasher.HashPassword(userDto.Password),
                Email = userDto.Email,
                CreatedAt = DateTime.UtcNow,
                EmploymentDate = userDto.EmploymentDate,
                PhoneNumber = userDto.PhoneNumber,
                Country = userDto.Country,
                City = userDto.City,
                RoleID = roleId,
                DateOfBirth = userDto.DateOfBirth
            };

            await _userRepository.AddUserAsync(user);

            if (userDto.Role == "DOCTOR" && !string.IsNullOrEmpty(userDto.DepartmentName))
            {
                var doctor = new Doctor
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserID = user.UserID
                };
                int DepId = await _userRepository.GetDepartmentIdByName(userDto.DepartmentName);
                await _userRepository.AddDoctorAsync(doctor);

                var Dep = new Doctor_Department
                {
                    DoctorID = doctor.DoctorID,
                    DepartmentID = DepId
                };

                await _userRepository.AddDoctorDepartment(Dep);
            }

            var response = new UserResponseDto
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

            return response;
        }
        public async Task<IEnumerable<UserResponse>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDtos = users.Select(user => new UserResponse
            {
                UserId = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.role,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                City = user.City,
                EmploymentDate = user.EmploymentDate,
                CreatedAt = user.CreatedAt
            }).ToList();

            return userDtos;
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUserById(id);

            if(user.RoleID == 2)
            {
                var doctor = await _userRepository.GetDoctorById(id);

                if (!string.IsNullOrEmpty(updateUserDto.FirstName))
                {
                    doctor.FirstName = updateUserDto.FirstName;
                }
                if (!string.IsNullOrEmpty(updateUserDto.LastName))
                {
                    doctor.LastName = updateUserDto.LastName;
                }
                await _userRepository.UpdateDoctor(doctor);
            }


            if (!string.IsNullOrEmpty(updateUserDto.FirstName))
            {
                user.FirstName = updateUserDto.FirstName;
            }
            if (!string.IsNullOrEmpty(updateUserDto.LastName))
            {
                user.LastName = updateUserDto.LastName;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Email))
            {
                user.Email = updateUserDto.Email;
            }
            if (!string.IsNullOrEmpty(updateUserDto.PhoneNumber))
            {
                user.PhoneNumber = updateUserDto.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Password))
            {
                user.PasswordHash = _passwordHasher.HashPassword(updateUserDto.Password);
            }
            await _userRepository.UpdateUser(user);
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);

            await _userRepository.DeleteUserAsync(user);
        }
        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByID(id);
            var department = "NONE";

            if(user.RoleID == 2)
            {
                var doctor = await _userRepository.GetDoctorById(id);
                department = await _userRepository.GetDepartmentByDoctorId(doctor.UserID);   
            }

            var response = new UserResponse
            {
                UserId = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.role,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                City = user.City,
                DepartmentName = department,
                EmploymentDate = user.EmploymentDate,
                CreatedAt = user.CreatedAt
            };
            return response;
        }
    }
}
