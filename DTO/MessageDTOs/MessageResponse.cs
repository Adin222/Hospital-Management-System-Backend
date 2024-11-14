namespace Hospital_Management_System.DTO.MessageDTOs
{
    public class MessageResponse
    {
        public required int MessageId {  get; set; }
        public required string SenderId { get; set; }
        public required string ReceiverId { get; set; }
        public required DateTime MessageReceived { get; set; }
        public int ChatId { get; set; }
        public string Message { get; set; }
    }
}
