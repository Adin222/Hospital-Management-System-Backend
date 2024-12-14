namespace Hospital_Management_System.DTO.RecordDTOs
{
    public class RecordResponse
    {
        public required int Id {  get; set; }
        public required int AppointmentId { get; set; }
        public required int DoctorId { get; set; }
        public required int PatientId { get; set; }
        public required int Quantity { get; set; }
        public required int Duration { get; set; }
        public required string Diagnosis { get; set; }
        public required string Notes { get; set; }
        public string Prescription { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string DoctorLastName { get; set; } = string.Empty;
        public string ReasonForVisit { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
