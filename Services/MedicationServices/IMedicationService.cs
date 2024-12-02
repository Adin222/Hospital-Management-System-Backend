using Hospital_Management_System.DTO.MedicationDTOs;

namespace Hospital_Management_System.Services.MedicationServices
{
    public interface IMedicationService
    {
        Task CreateMedication(MedicationRequest request);
        Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync(int patientId);
    }
}
