namespace Hospital_Management_System.DTO.RecordDTOs
{
    public class RecordResponse
    {
        public required int Id {  get; set; }
        public required string DoctorName { get; set; }
        public required string PatientName { get; set; }
        public DateTime? AppointmentTime { get; set; }
    }
}
