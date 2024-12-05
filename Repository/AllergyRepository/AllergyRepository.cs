using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.AllergyRepository
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly ApplicationDbContext _context;
        public AllergyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAllergy(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();
        }

        public async Task ConnectAllergy(Patient patient, Allergy allergy)
        {
            if (!patient.Allergies.Contains(allergy))
            {
                patient.Allergies.Add(allergy);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Allergy> GetAllergyById(int allergyId)
        {
            var allergy = await _context.Allergies.FindAsync(allergyId) ?? throw new KeyNotFoundException("Allergy doesn't exist");
            return allergy;
        }

        public async Task<ICollection<Allergy>> GetAllPatientAllergies(int patientId)
        {
            var allergies = await _context.Patients
                .Where(p => p.PatientID == patientId)
                .Include(p => p.Allergies)
                .SelectMany(p => p.Allergies)
                .ToListAsync();
            return allergies;
        }
    }
}
