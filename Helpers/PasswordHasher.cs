using System.Security.Cryptography;
using System.Text;


namespace Hospital_Management_System.Helpers
{
    public class PasswordHasher
    {
        public string HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                string passwordString = Convert.ToBase64String(hashedBytes);
                return passwordString;
            }
        }
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);
            return enteredPasswordHash == storedHash;
        }
    }
}
