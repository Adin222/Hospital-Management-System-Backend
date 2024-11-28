using Hospital_Management_System.DTO.MessageDTOs;
using Hospital_Management_System.Mappers.MessageMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.ChatRepository;
using Hospital_Management_System.Repository.MessageRepository;

namespace Hospital_Management_System.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
        }
        public async Task AddMessage(string message, string sender, string receiver, string name)
        {
            var chatId = await _chatRepository.GetChatIdByNameAndUserId(name, sender);
            var mess = new Message(sender, receiver, message, chatId);

            await _messageRepository.AddMessage(mess);
        }
        public async Task<IEnumerable<MessageResponse>> GetAllChatMessagesAsync(string chatName)
        {
            var messages = await _messageRepository.GetMessagesByChatName(chatName);

            var response = messages.Select(message => message.ToMessageResponseDto()).ToList();

            return response;
        }
    }
}
