using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Services.MedicationServices
{
    public interface IMedicationService
    {
        Task CreateMedication(MedicationRequest request);
        Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync(int patientId);
        Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync();
        Task<ICollection<MedicationResponse>> GetUnassignedMedication(int patientId);
        Task AddNewPatientMedicationAsync(MedicationRequest request, int patientId);
        Task RemovePatientMedicationAsync(MedicationRequest request, int patientId);

    }
}
