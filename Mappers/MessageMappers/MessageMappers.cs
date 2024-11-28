using Hospital_Management_System.DTO.MessageDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.MessageMappers
{
    public static class MessageMappers
    {
        public static MessageResponse ToMessageResponseDto(this Message message)
        {
            return new MessageResponse
            {
                MessageId = message.MessageId,
                SenderId = message.SenderId,
                MessageReceived = message.MessageReceived,
                ReceiverId = message.ReceiverId,
                Message = message.MessageInformation
            };
        }
    }
}
