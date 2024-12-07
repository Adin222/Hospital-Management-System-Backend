namespace Hospital_Management_System.Services.PatientInformationServices
{
    public interface IPatientInformationService
    {
        Task UpdateAllergyState(int patientId);
        Task UpdateIllnessState(int patientId);
        Task UpdateMedicationState(int patientId);
    }
}
