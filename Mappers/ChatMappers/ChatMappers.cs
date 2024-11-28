using Hospital_Management_System.DTO.ChatDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.ChatMappers
{
    public static class ChatMappers
    {
        public static ChatResponse ToChatDto(this Chat chat)
        {
            return new ChatResponse
            {
                Id = chat.ChatId,
                ChatName = chat.ChatName,
                UserId = chat.UserId,
            };
        }
    }
}
