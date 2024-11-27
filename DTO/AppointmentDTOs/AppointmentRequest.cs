namespace Hospital_Management_System.DTO.AppointmentDTOs
{
    public class AppointmentRequest
    {
        public required string JMBG { get; set; }
        public required string ReasonForVisit { get; set; }
        public required string Status { get; set; }
        public required double Price { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
