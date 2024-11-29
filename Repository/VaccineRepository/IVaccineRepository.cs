using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.VaccineRepository
{
    public interface IVaccineRepository
    {
        public Task<ICollection<Vaccine>> GetAllVaccines();
        public Task AddVaccine(Vaccine vaccine);
    }
}
