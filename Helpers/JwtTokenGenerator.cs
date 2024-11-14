using Hospital_Management_System.DTO.AuthDTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_Management_System.Helpers
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _config;
        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GenerateJWTTokenAsync(LoggedUserDto user, string role)
        {
            var claims = new List<Claim>
            {
              new("userId", user.Id.ToString()),
              new("email", user.Email),
              new("role", role),
              new("name", user.FirstName),
              new("lastname", user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ApplicationSettings:JWT_Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(jwtToken));
        }
    }
}
