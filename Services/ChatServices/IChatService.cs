using Hospital_Management_System.DTO.ChatDTOs;

namespace Hospital_Management_System.Services.ChatServices
{
    public interface IChatService
    {
        Task CreateChat(string user, string name);
        Task DeleteChatById(int chatId);
        Task<IEnumerable<ChatResponse>> GetAllChatsByUserId(int Id);
        Task DeleteAllChatsAsync(int id);
    }
}
