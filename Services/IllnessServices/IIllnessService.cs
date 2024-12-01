using Hospital_Management_System.DTO.IllnessDTOs;

namespace Hospital_Management_System.Services.IllnessServices
{
    public interface IIllnessService
    {
        Task CreateIllness(IllnessRequest illness);
        Task<IEnumerable<IllnessResponse>> GetAllChronicIllnessesAsync(int patientId);
    }
}
