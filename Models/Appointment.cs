using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Hospital_Management_System.DTO.AppointmentDTOs;


namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        public Appointment() { }

        public Appointment(AppointmentRequest req, int doctorId, int patientId, int receptionistId)
        {
            DoctorID = doctorId;
            ReceptionistID = receptionistId;
            PatientID = patientId;
            AppointmentDateTime = req.AppointmentDate;
            ReasonForVisit = req.ReasonForVisit;
            Status = req.Status;
            Price = req.Price;
            PatientJMBG = req.JMBG;
        }

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
        public string ReasonForVisit { get; set; }
        [MaxLength(14)]
        public string PatientJMBG { get; set; }

        [MaxLength(25)]
        public string Status { get; set; }
        public double Price { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = [];
    }
}
