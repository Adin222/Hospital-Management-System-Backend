using Hospital_Management_System.DTO.AuthDTOs;
using Hospital_Management_System.Helpers;
using Hospital_Management_System.Repository.AuthRepository;

namespace Hospital_Management_System.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly PasswordHasher _passwordHasher;
        private JwtTokenGenerator _jwtTokenGenerator;
        private readonly IAuthRepository _authRepository;

        public AuthService(JwtTokenGenerator jwtTokenGenerator, PasswordHasher passwordHasher, IAuthRepository authRepository)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _authRepository = authRepository;
        }

        public async Task<string> LoginAsync(string Email, string Password)
        {
            var user = await _authRepository.GetUserByEmail(Email);

            var res = new LoggedUserDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = await _authRepository.GetRoleByID(user.RoleID)
            };

            var role = await _authRepository.GetRoleByID(user.RoleID);

            if (!_passwordHasher.VerifyPassword(Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }
            var token = await _jwtTokenGenerator.GenerateJWTTokenAsync(res, role);
            return token;
        }
    }
}
