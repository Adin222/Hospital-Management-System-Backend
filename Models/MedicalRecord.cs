using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Hospital_Management_System.DTO.RecordDTOs;

namespace Hospital_Management_System.Models
{
    public class MedicalRecord
    {
        public MedicalRecord() { }

        public MedicalRecord(RecordRequest request, int patientId, int doctorId, int appointmentId)
        {
            PatientID = patientId;
            DoctorID = doctorId;
            AppointmentID = appointmentId;
            Diagnosis = request.Diagnosis;
            Prescription = request.Prescription;
            Notes = request.Notes;
            Quantity = request.Quantity;
            Duration = request.Duration;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

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
        public int Quantity { get; set; }
        public int Duration { get; set; }

        [MaxLength(1000)]
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
