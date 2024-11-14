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
        public async Task AddMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Remove(record);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecords()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordById(int id)
        {
            var record = await _context.MedicalRecords.FindAsync(id) ?? throw new KeyNotFoundException("Medical record doesn't exist");
            return record;
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
