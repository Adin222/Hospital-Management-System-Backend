using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessage(Message message)
        {
           _context.Messages.Add(message);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatName(string chatName)
        {
            var messages = await _context.Messages
                .Include(ch => ch.Chat)
                .Where(ms => ms.Chat.ChatName == chatName)
                .OrderBy(m => m.MessageReceived)
                .ToListAsync();
            return messages;
        }

        public async Task<Message> GetMessageById(int id)
        {
            var message = await _context.Messages.FindAsync(id) ?? throw new KeyNotFoundException("Message not found");
            return message;
        }

    }
}
