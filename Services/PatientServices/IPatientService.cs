using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.DTO.PatientDTOs;

namespace Hospital_Management_System.Services.PatientServices
{
    public interface IPatientService
    {
        Task<PatientDto> CreatePatientAsync(PatientDto patient);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task DeletePatientByIdAsync(int id);
        Task UpdatePatientByIdAsync(int id, PatientUpdateDto patientDto);
        Task<PatientDto> GetPatientBySSNAsync(string ssn);
        Task RegisterPatientChronicIllness(IEnumerable<IllnessRequest> requests, int patientId);
    }
}
