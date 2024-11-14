using Hospital_Management_System.DTO.RecordDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Services.RecordServices
{
    public interface IRecordService
    {
        Task<RecordResponse> CreateRecord(RecordRequest req, int patId, int docId, int appId);
        Task DeleteMedicalRecordAsync(int Id);
        Task<RecordResponse> GetMedicalRecordByIdAsync(int Id);
        Task<IEnumerable<RecordResponse>> GetAllMedicalRecordsAsync();
        Task IsDataValid(int docId, int patId, int appId);
        Task UpdateMedicalRecordByIdAsync(RecordRequest req, int id);
    }
}
