using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.MedicationRepository
{
    public interface IMedicationRepository
    {
        Task AddMedication(Medication medication);
        Task<Medication> GetMedicationById(int medicationId);
        Task ConnectMedicationAndPatient(Patient patient, Medication medication);
        Task<IEnumerable<Medication>> GetAllMedicationByPatientId(int patientId);
    }
}
