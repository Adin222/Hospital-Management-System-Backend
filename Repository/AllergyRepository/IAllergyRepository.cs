using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.AllergyRepository
{
    public interface IAllergyRepository
    {
        Task AddAllergy(Allergy allergy);
        Task<Allergy> GetAllergyById(int allergyId);
        Task<ICollection<Allergy>> GetAllPatientAllergies(int patientId);
        Task ConnectAllergy(Patient patient, Allergy allergy);
    }
}
