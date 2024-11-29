namespace Hospital_Management_System.Models
{
    public class Allergy
    {
        public int AllergyId { get; set; }
        public string AllergyName { get; set; } = string.Empty;
        public ICollection<Patient> PatientAllergies { get; set; } = [];
    }
}
