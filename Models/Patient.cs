using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [MaxLength(25)]
        public required string FirstName { get; set; }

        [MaxLength(25)]
        public required string LastName { get; set; }
        [MaxLength(15)]
        public required string DateOfBirth { get; set; }

        [MaxLength(255)]
        public required string Address { get; set; }

        [MaxLength(25)]
        public required string Email { get; set; }

        [MaxLength(30)]
        public required string PhoneNumber { get; set; }

        [MaxLength(30)]
        public required string City { get; set; }

        [MaxLength(30)]
        public required string Country { get; set; }

        [MaxLength(30)]
        public required string Education {  get; set; }
        [MaxLength(30)]
        public required string JMBG { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
