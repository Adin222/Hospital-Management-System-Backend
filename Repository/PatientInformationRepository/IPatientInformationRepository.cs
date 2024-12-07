using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.PatientInformationRepository
{
    public interface IPatientInformationRepository
    {
        Task AddPatientInformation(PatientInformation patientInformation);
        Task<PatientInformation> GetPatientInfoById(int patientId);
        Task UpdatePatientInformation(PatientInformation patientInformation);
        Task<bool> HasAllergy(int patientId);
        Task<bool> HasMedication(int patientId);
        Task<bool> HasIllness(int patientId);
    }
}
