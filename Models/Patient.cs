using Hospital_Management_System.DTO.PatientDTOs;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public Patient() { }

        public Patient(PatientDto patient)
        {
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            DateOfBirth = patient.DateOfBirth;
            Address = patient.Address;
            Email = patient.Email;
            PhoneNumber = patient.PhoneNumber;
            City = patient.City;
            Country = patient.Country;
            Education = patient.Education;
            JMBG = patient.JMBG;
            CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public int PatientID { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(15)]
        public string DateOfBirth { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(25)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string Country { get; set; }

        [MaxLength(30)]
        public string Education {  get; set; }
        [MaxLength(30)]
        public string JMBG { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
