using Hospital_Management_System.DTO.RecordDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Services.RecordServices
{
    public interface IRecordService
    {
        Task CreateRecord(IEnumerable<RecordRequest> requests, int patId, int docId, int appId);
        Task DeleteMedicalRecordAsync(int Id);
        Task<RecordResponse> GetMedicalRecordByIdAsync(int Id);
        Task<IEnumerable<RecordResponse>> GetAllMedicalRecordsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<RecordResponse>> GetMedicalRecordsByDoctorAndPatient(int doctorId, int patientId);
        Task<IEnumerable<RecordResponse>> GetAllMedicalRecordsAsync();
        Task IsDataValid(int docId, int patId, int appId);
        Task UpdateMedicalRecordByIdAsync(RecordRequest req, int id);
    }
}
