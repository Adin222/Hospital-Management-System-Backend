using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [MaxLength(25)]
        public required string FirstName { get; set; }

        [MaxLength(25)]
        public required string LastName { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Doctor_Department> DoctorDepartments { get; set; }
    }
}
