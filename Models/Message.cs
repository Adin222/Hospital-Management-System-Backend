using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public required string SenderId { get; set; }
        public required string ReceiverId { get; set; }
        public int ChatId { get; set; }
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
        public string MessageInformation { get; set; }
    }
}
