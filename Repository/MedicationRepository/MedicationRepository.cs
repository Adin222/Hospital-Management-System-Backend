using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.MedicationRepository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly ApplicationDbContext _context;
        
        public MedicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMedication(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
        }

        public async Task ConnectMedicationAndPatient(Patient patient, Medication medication)
        {
            if (!patient.Medications.Contains(medication))
            {
                patient.Medications.Add(medication);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Medication>> GetAllMedication()
        {
            var medications = await _context.Medications.ToListAsync();
            return medications;
        }

        public async Task<IEnumerable<Medication>> GetAllMedicationByPatientId(int patientId)
        {
            var medications = await _context.Patients
                .Where(p => p.PatientID == patientId)
                .Include(p => p.Medications)
                .SelectMany(s => s.Medications)
                .ToListAsync();

            return medications;
        }

        public async Task<Medication> GetMedicationById(int medicationId)
        {
            var medication = await _context.Medications.FindAsync(medicationId) ?? throw new KeyNotFoundException("Medication doesn't exist");

            return medication;
        }
    }
}
