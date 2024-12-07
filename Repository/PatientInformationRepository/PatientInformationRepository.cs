using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.PatientInformationRepository
{
    public class PatientInformationRepository : IPatientInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPatientInformation(PatientInformation patientInformation)
        {
            _context.PatientInformation.Add(patientInformation);
            await _context.SaveChangesAsync();
        }

        public async Task<PatientInformation> GetPatientInfoById(int patientId)
        {
            var patientInformation = await _context.PatientInformation
                .Where(p => p.PatientId == patientId)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient information doesn't exist");

            return patientInformation;
        }

        public async Task<bool> HasAllergy(int patientId)
        {
            var hasAllergy = await _context.PatientInformation
                .Where(p => p.PatientId == patientId)
                .Select(pi => pi.Allergy)
                .FirstOrDefaultAsync();

            return hasAllergy;
        }

        public async Task<bool> HasIllness(int patientId)
        {
            var hasIllness = await _context.PatientInformation
                 .Where(p => p.PatientId == patientId)
                 .Select(pi => pi.ChronicIllness)
                 .FirstOrDefaultAsync();

            return hasIllness;
        }

        public async Task<bool> HasMedication(int patientId)
        {
            var hasMedication = await _context.PatientInformation
                .Where(p => p.PatientId == patientId)
                .Select(pi => pi.Medication)
                .FirstOrDefaultAsync();

            return hasMedication;
        }

        public async Task UpdatePatientInformation(PatientInformation patientInformation)
        {
            _context.Update(patientInformation);
            await _context.SaveChangesAsync();
        }
    }
}
