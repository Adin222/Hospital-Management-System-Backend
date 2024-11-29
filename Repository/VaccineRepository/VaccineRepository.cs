using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.VaccineRepository
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly ApplicationDbContext _context;

        public VaccineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVaccine(Vaccine vaccine)
        {
            _context.Add(vaccine);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Vaccine>> GetAllVaccines()
        {
            var vaccines = await _context.Vaccines.ToListAsync();
            return vaccines;
        }
    }
}
