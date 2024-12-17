using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.PatientVaccineRepository
{
    public class PatientVaccineRepository : IPatientVaccineRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientVaccineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPatientVaccinations(IEnumerable<PatientVaccine> patientVaccinations)
        {
            _context.PatientVaccines.AddRange(patientVaccinations);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientVaccine>> GetAllVaccinationsByPatientId(int patientId)
        {
            var vaccinations = await _context.Patients
                .Include(p => p.PatientVaccines)
                .ThenInclude(pv => pv.Vaccine)
                .Where(p => p.PatientID == patientId)
                .SelectMany(p => p.PatientVaccines)
                .ToListAsync();

            return vaccinations;
        }

        public async Task<PatientVaccine> GetPatientVaccineById(int id)
        {
            var patientVaccine = await _context.PatientVaccines
                .Where(pt => pt.VaccineId == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient vaccination doesn't exist");
            return patientVaccine;
        }

        public async Task<bool> PatientVaccineExists(int patientId)
        {
            var exists = await _context.PatientVaccines.AnyAsync(p => p.PatientId == patientId);

            return exists;
        }

        public async Task UpdatePatientVaccinations(IEnumerable<PatientVaccine> patientVaccinations, int patientId)
        {
           foreach(var request in patientVaccinations)
            {
                await _context.PatientVaccines
                    .Where(v => v.VaccineId == request.VaccineId && v.PatientId == patientId)
                    .ExecuteUpdateAsync(s => s.SetProperty(s => s.Status, request.Status));
            }
        }
    }
}
