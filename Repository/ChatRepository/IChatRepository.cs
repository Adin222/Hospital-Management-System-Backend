using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.ChatRepository
{
    public interface IChatRepository
    {
        Task<Chat> GetChatById(int id);
        Task<IEnumerable<Chat>> GetAllChats();
        Task AddChat(Chat chat);
        Task DeleteChat(Chat chat);
        Task DeleteAllChatsByUserId(int Id);
        Task<bool> ChatExists(string name, string userId);
        Task<int> GetChatIdByNameAndUserId(string name, string senderId);
        Task<IEnumerable<Chat>> GetAllChatsByUserId(int Id);
    }
}
