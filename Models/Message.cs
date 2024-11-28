using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Message
    {
        public Message() { }

        public Message(string sender, string receiver, string message, int chatId)
        {
            SenderId = sender;
            ReceiverId = receiver;
            MessageInformation = message;
            MessageReceived = DateTime.UtcNow;
            ChatId = chatId;
        }

        [Key]
        public int MessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime MessageReceived { get; set; }
        public int ChatId { get; set; }
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
        public string MessageInformation { get; set; }
    }
}
