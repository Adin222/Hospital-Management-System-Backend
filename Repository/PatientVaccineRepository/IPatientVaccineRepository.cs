using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.PatientVaccineRepository
{
    public interface IPatientVaccineRepository
    {
        Task<IEnumerable<PatientVaccine>> GetAllVaccinationsByPatientId(int patientId);
        Task AddPatientVaccinations(IEnumerable<PatientVaccine> patientVaccine);
        Task<bool> PatientVaccineExists(int patientId);
    }
}
