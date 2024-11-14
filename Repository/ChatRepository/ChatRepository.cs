using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.ChatRepository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;   
        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddChat(Chat chat)
        {
           _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChatExists(string name, string userId)
        {
            var chat = await _context.Chats
                .FirstOrDefaultAsync(ch => ch.ChatName == name && ch.UserId == int.Parse(userId));
            return chat != null;
        }

        public async Task DeleteAllChatsByUserId(int Id)
        {
            var chats = await _context.Chats.Where(ch => ch.UserId == Id).ToListAsync();
            _context.RemoveRange(chats);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChat(Chat chat)
        {
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Chat>> GetAllChats()
        {
            var chats = await _context.Chats.ToListAsync();
            return chats;
        }

        public async Task<IEnumerable<Chat>> GetAllChatsByUserId(int Id)
        {
            var chats = await _context.Chats.Where(ch => ch.UserId == Id).ToListAsync();
            return chats;
        }

        public async Task<Chat> GetChatById(int id)
        {
            var chat = await _context.Chats.FindAsync(id) ?? throw new KeyNotFoundException("Chat doesn't exist");
            return chat;
        }

        public async Task<int> GetChatIdByNameAndUserId(string name, string senderId)
        {
            var chatId = await _context.Chats
                .Where(s => s.ChatName == name && s.UserId == int.Parse(senderId))
                .Select(c => c.ChatId)
                .FirstOrDefaultAsync();
            return chatId;
        }
    }
}
