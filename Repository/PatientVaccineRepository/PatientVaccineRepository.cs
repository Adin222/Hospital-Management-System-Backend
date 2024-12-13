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

        public async Task<bool> PatientVaccineExists(int patientId)
        {
            var exists = await _context.PatientVaccines.AnyAsync(p => p.PatientId == patientId);

            return exists;
        }
    }
}
