using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public ICollection<Patient> PatientMedications { get; set; } = [];
    }
}
