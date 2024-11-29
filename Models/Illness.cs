namespace Hospital_Management_System.Models
{
    public class Illness
    {
        public int IllnessId { get; set; }
        public string IllnessName { get; set; } = string.Empty;
        public ICollection<Patient> PatientIllnesses { get; set; } = [];
    }
}
