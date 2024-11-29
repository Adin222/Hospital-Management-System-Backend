using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class PatientVaccine
    {
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int VaccineId { get; set; }
        [ForeignKey("VaccineId")]
        public Vaccine Vaccine { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
