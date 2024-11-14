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
            var mess = new Message
            {
                SenderId = sender,
                ReceiverId = receiver,
                MessageInformation = message,
                ChatId = chatId
            };
            await _messageRepository.AddMessage(mess);
        }
    }
}
