using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class PatientInformation
    {
        [Key]
        public int PatientInformationId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public bool Allergy { get; set; }
        public bool ChronicIllness { get; set; }
        public bool Medication { get; set; }
    }
}
