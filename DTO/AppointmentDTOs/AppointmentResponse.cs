namespace Hospital_Management_System.DTO.AppointmentDTOs
{
    public class AppointmentResponse
    {
        public required int Id { get; set; }
        public required string DoctorName { get; set; }
        public required string ReceptionistName { get; set; }
        public required string PatientName { get; set; }
        public required string ReasonForVisit { get; set; }
        public DateTime? Reservation { get; set; }
    }
}
