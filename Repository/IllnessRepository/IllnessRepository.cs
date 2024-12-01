using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.IllnessRepository
{
    public class IllnessRepository : IIllnessRepository
    {
        private readonly ApplicationDbContext _context;

        public IllnessRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddIllness(Illness illness)
        {
            _context.Add(illness);
            await _context.SaveChangesAsync();
        }

        public async Task ConnectIllness(Patient patient, Illness illness)
        {
            if (!patient.Illnesses.Contains(illness))
            {
                patient.Illnesses.Add(illness);
                await _context.SaveChangesAsync();
            }  
        }

        public async Task<ICollection<Illness>> GetAllIllnessesByPatientId(int patientId)
        {
            var illnesses = await _context.Patients
                .Where(p => p.PatientID == patientId)
                .Include(p => p.Illnesses)
                .SelectMany(p => p.Illnesses)
                .ToListAsync();

            return illnesses;
        }

        public async Task<Illness> GetIllnessById(int illnessId)
        {
            var illness = await _context.Illnesses.FindAsync(illnessId) ?? throw new KeyNotFoundException("Illness doesn't exist");
            return illness;
        }

    }
}
