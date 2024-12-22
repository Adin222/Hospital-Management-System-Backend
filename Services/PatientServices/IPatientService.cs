using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.DTO.MedicationDTOs;
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
        Task<bool> PatientAllergyExists(int patientId);
        Task<bool> PatientIllnessExists(int patientId);
        Task<bool> PatientMedicationExists(int patientId);
        Task<bool> PatientVaccinationExists(int patientId);
        Task<bool> PatientMedicalRecordExists(int patientId);
        Task RegisterPatientChronicIllness(IEnumerable<IllnessRequest> requests, int patientId);
        Task RegisterPatientMedication(IEnumerable<MedicationRequest> requests, int patientId);
        Task RegisterPatientAllergy(IEnumerable<AllergyRequest> requests, int patientId);
    }
}
