using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.IllnessDTOs;

namespace Hospital_Management_System.Services.IllnessServices
{
    public interface IIllnessService
    {
        Task CreateIllness(IllnessRequest illness);
        Task<IEnumerable<IllnessResponse>> GetAllChronicIllnessesAsync(int patientId);
        Task<IEnumerable<IllnessResponse>> GetAllIllnesses();
        Task AddNewPatientIllnessAsync(IllnessRequest request, int patientId);
        Task<ICollection<IllnessResponse>> GetUnassignedIllnesses(int patientId);
    }
}
