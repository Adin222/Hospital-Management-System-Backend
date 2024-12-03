namespace Hospital_Management_System.DTO.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public required int Id { get; set; }
        public required int DoctorId { get; set; }
        public required int ReceptionistId { get; set; }
        public required int PatientId { get; set; }
        public required string ReasonForVisit { get; set; }
        public required string Status { get; set; }
        public required string SSN { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
