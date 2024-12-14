using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.RecordsRepository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ApplicationDbContext _context;
        public RecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMedicalRecord(IEnumerable<MedicalRecord> records)
        {
            _context.MedicalRecords.AddRange(records);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Remove(record);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecords()
        {
            var records = await _context.MedicalRecords.ToListAsync();
            return records;
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsByPatientId(int patientId)
        {
            var records = await _context.MedicalRecords.Include(p => p.Doctor).Include(a => a.Appointment).Where(dc => dc.PatientID == patientId).ToListAsync();
            return records;
        }

        public async Task<MedicalRecord> GetMedicalRecordById(int id)
        {
            var record = await _context.MedicalRecords.FindAsync(id) ?? throw new KeyNotFoundException("Medical record doesn't exist");
            return record;
        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByDoctorAndPatient(int doctorId, int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId) ?? throw new KeyNotFoundException("Patient doesn't exist");
            var doctor = await _context.Doctors.FindAsync(doctorId) ?? throw new KeyNotFoundException("Doctor doesn't exist");

            var records = await _context.MedicalRecords
                .Where(p => p.DoctorID == doctorId && p.PatientID == patientId)
                .ToListAsync();

            return records;
        }

        public async Task<bool> GetRecordByAppointmentId(int id)
        {
            var appointment = await _context.MedicalRecords
                .Where(ap => ap.AppointmentID == id)
                .FirstOrDefaultAsync();

            return appointment != null;
        }


        public async Task UpdateMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
        }
    }
}
