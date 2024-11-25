using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        public int DoctorID { get; set; }

        [ForeignKey("DoctorID")]
        public Doctor Doctor { get; set; }
        public int ReceptionistID { get; set; }

        [ForeignKey("ReceptionistID")]
        public User Receptionist { get; set; }

        public DateTime? AppointmentDateTime { get; set; }

        [MaxLength(400)]
        public required string ReasonForVisit { get; set; }
        [MaxLength(14)]
        public required string PatientJMBG { get; set; }

        [MaxLength(25)]
        public required string Status { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = [];
    }
}
