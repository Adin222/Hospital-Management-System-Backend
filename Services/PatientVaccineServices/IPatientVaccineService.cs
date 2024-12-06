using Hospital_Management_System.DTO.PatientVaccineDTOs;

namespace Hospital_Management_System.Services.PatientVaccineServices
{
    public interface IPatientVaccineService
    {
        Task<IEnumerable<PatientVaccineResponse>> GetPatientVaccinationsAsync(int patientId);
        Task CreatePatientVaccinations(IEnumerable<PatientVaccineRequest> patientVaccineRequests, int patientId);
    }
}
