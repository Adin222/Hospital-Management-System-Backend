using Hospital_Management_System.DTO.AuthDTOs;
using Hospital_Management_System.DTO.UserDTOs;
using Hospital_Management_System.Services.AuthServices;
using Hospital_Management_System.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.UserController
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpPost("user/login")]
        public async Task<IActionResult> Login([FromBody] LoginBody loginRequest)
        {
             var token = await _authService.LoginAsync(loginRequest.Email, loginRequest.Password);
             return Ok(new { Token = token });

        }

        [HttpPost("user")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] UserDto userBody)
        {
             var user = await _userService.CreateUserAsync(userBody);
             return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR,RECEPTIONIST")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPut("user/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUserAsync(id, updateUserDto);
            return Ok("User has been successfully updated");
        }

        [HttpDelete("user/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok("User has been successfully deleted");
        }

        [HttpPut("user")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto updateUserDto)
        {
            var userId = User.FindFirst("userId")?.Value ?? throw new KeyNotFoundException("Claim doesn't exist");
            await _userService.UpdateUserAsync(int.Parse(userId), updateUserDto);
            return Ok("Profile data has been successfully updated");
        }

        [HttpGet("user/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,RECEPTIONIST")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
    }
}

