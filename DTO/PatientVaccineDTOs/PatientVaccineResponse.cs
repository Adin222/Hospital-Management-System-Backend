namespace Hospital_Management_System.DTO.PatientVaccineDTOs
{
    public class PatientVaccineResponse
    {
        public int PatientId { get; set; }
        public int VaccineId { get; set; }
        public string VaccineName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
