using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.MessageRepository
{
    public interface IMessageRepository
    {
        Task<Message> GetMessageById(int id);
        Task AddMessage(Message message);
        Task<IEnumerable<Message>> GetMessagesByChatName(string chatName);
    }
}
