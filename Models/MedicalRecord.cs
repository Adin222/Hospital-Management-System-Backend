using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordID { get; set; }
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        public int DoctorID { get; set; }

        [ForeignKey("DoctorID")]
        public Doctor Doctor { get; set; }
        public int AppointmentID { get; set; }

        [ForeignKey("AppointmentID")]
        public Appointment Appointment { get; set; }

        [MaxLength(255)]
        public string Diagnosis { get; set; }

        [MaxLength(1000)]
        public string Prescription { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
