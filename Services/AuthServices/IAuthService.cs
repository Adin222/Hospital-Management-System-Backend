namespace Hospital_Management_System.Services.AuthServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string Email, string Password);
    }
}
