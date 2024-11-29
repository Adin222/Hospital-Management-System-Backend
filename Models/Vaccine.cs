namespace Hospital_Management_System.Models
{
    public class Vaccine
    {
        public int VaccineId { get; set; }
        public string VaccineName { get; set; } = string.Empty;
        public ICollection<PatientVaccine> PatientVaccines { get; set; } = [];
    }
}
