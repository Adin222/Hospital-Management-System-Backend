using Hospital_Management_System.DTO.ChatDTOs;
using Hospital_Management_System.Mappers.ChatMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.ChatRepository;

namespace Hospital_Management_System.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task CreateChat(string user, string name)
        {
            if(!await _chatRepository.ChatExists(name, user))
            {
                var chat = new Chat(name, user);

                await _chatRepository.AddChat(chat);
            }
        }

        public async Task DeleteAllChatsAsync(int id)
        {
            await _chatRepository.DeleteAllChatsByUserId(id);
        }

        public async Task DeleteChatById(int chatId)
        {
            var chat = await _chatRepository.GetChatById(chatId);
            await _chatRepository.DeleteChat(chat);
        }

        public async Task<IEnumerable<ChatResponse>> GetAllChatsByUserId(int Id)
        {
            var chats = await _chatRepository.GetAllChatsByUserId(Id);

            var response = chats.Select(chat => chat.ToChatDto()).ToList();

            return response;
        }
    }
}
