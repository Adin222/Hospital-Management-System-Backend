using Hospital_Management_System.DTO.RecordDTOs;
using Hospital_Management_System.Mappers.RecordMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.AppointmentRepository;
using Hospital_Management_System.Repository.PatientRepository;
using Hospital_Management_System.Repository.RecordsRepository;
using Hospital_Management_System.Repository.UserRepository;

namespace Hospital_Management_System.Services.RecordServices
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public RecordService(IRecordRepository recordRepository, IUserRepository userRepository, IPatientRepository patientRepository, IAppointmentRepository appointmentRepository)
        {
           _recordRepository = recordRepository;
           _userRepository = userRepository;
           _patientRepository = patientRepository;
           _appointmentRepository = appointmentRepository;
        }
        public async Task CreateRecord(IEnumerable<RecordRequest> requests, int patId, int docId, int appId)
        {
            await IsDataValid(docId, patId, appId);

            var records = requests.Select(record => new MedicalRecord(record, patId, docId, appId));

            var appointment = await _appointmentRepository.GetAppointmentById(appId);

            appointment.Status = "Done";

            await _appointmentRepository.UpdateAppointment(appointment);

            await _recordRepository.AddMedicalRecord(records);
        }
        public async Task DeleteMedicalRecordAsync(int Id)
        {
            var record = await _recordRepository.GetMedicalRecordById(Id);
            await _recordRepository.DeleteMedicalRecord(record);
        }
        public async Task<RecordResponse> GetMedicalRecordByIdAsync(int Id)
        {
            var record = await _recordRepository.GetMedicalRecordById(Id);

            var response = record.ToRecordResponseDto();

            return response;
        }

        public async Task<IEnumerable<RecordResponse>> GetAllMedicalRecordsByPatientIdAsync(int patientId)
        {
            var records = await _recordRepository.GetAllMedicalRecordsByPatientId(patientId);

            var response = records.Select(record => record.ToRecordResponseDto()).ToList();

            return response;
        }

        public async Task UpdateMedicalRecordByIdAsync(RecordRequest req, int id)
        {
            var record = await _recordRepository.GetMedicalRecordById(id);
            bool Edited = false;

            if (!String.IsNullOrEmpty(req.Prescription))
            {
                record.Prescription = req.Prescription;
                Edited = true;
            }
            if (!String.IsNullOrEmpty(req.Notes))
            {
                record.Notes = req.Notes;
                Edited = true;
            }

            if (req.Quantity != 0)
            {
                record.Quantity = req.Quantity;
                Edited = true;
            }

            if (!String.IsNullOrEmpty(req.Diagnosis))
            {
                record.Diagnosis = req.Diagnosis;
                Edited = true;
            }
            if (Edited) 
            {
                record.UpdatedAt = DateTime.UtcNow;
                await _recordRepository.UpdateMedicalRecord(record);
            } 
        }

        public async Task IsDataValid(int docId, int patId, int appId)
        {
            await _patientRepository.PatientExists(patId);
            await _appointmentRepository.AppointmentExists(appId);
            await _userRepository.DoctorExists(docId);

            if (await _recordRepository.GetRecordByAppointmentId(appId))
            {
                throw new ApplicationException("Record already exists");
            }

            var appointment = await _appointmentRepository.GetAppointmentById(appId);

            if (appointment.DoctorID != docId || appointment.PatientID != patId) 
            {
               throw new InvalidOperationException("Invalid data");
            } 
        }

        public async Task<IEnumerable<RecordResponse>> GetAllMedicalRecordsAsync()
        {
            var records = await _recordRepository.GetAllMedicalRecords();

            var response = records.Select(record => record.ToRecordResponseDto()).ToList();

            return response;
        }

        public async Task<IEnumerable<RecordResponse>> GetMedicalRecordsByDoctorAndPatient(int doctorId, int patientId)
        {
            var records = await _recordRepository.GetMedicalRecordsByDoctorAndPatient(doctorId, patientId);

            var response = records.Select(record => record.ToRecordResponseDto());
            return response;
        }
    }
}