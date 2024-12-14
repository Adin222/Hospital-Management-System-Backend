using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.RecordsRepository
{
    public interface IRecordRepository
    {
        Task<MedicalRecord> GetMedicalRecordById(int id);
        Task AddMedicalRecord(IEnumerable<MedicalRecord> records);
        Task UpdateMedicalRecord(MedicalRecord record);
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsByPatientId(int patientId);
        Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByDoctorAndPatient(int doctorId, int patientId);
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecords();
        Task DeleteMedicalRecord(MedicalRecord record);
        Task<bool> GetRecordByAppointmentId(int id);
    }
}
