using Hospital_Management_System.DTO.AllergyDTOs;

namespace Hospital_Management_System.Services.AllergyServices
{
    public interface IAllergyService
    {
        Task CreateAllergy(AllergyRequest request);
        Task<IEnumerable<AllergyResponse>> GetAllAllergiesAsync(int patientId);
        Task<IEnumerable<AllergyResponse>> GetAllAllergies();
        Task<ICollection<AllergyResponse>> GetUnassignedAllergies(int patientId);
        Task AddNewPatientAllergyAsync(AllergyRequest request, int patientId);
    }
}
