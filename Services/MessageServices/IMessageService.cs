using Hospital_Management_System.DTO.MessageDTOs;

namespace Hospital_Management_System.Services.MessageServices
{
    public interface IMessageService
    {
        Task AddMessage(string message, string sender, string receiver, string name);
        Task<IEnumerable<MessageResponse>> GetAllChatMessagesAsync(string chatName);
    }
}
