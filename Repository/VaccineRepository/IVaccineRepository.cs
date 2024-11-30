using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.VaccineRepository
{
    public interface IVaccineRepository
    {
        Task<ICollection<Vaccine>> GetAllVaccines();
        Task AddVaccine(Vaccine vaccine);
        Task<bool> VaccineExistsAsync(int vaccineId);
        Task<int> GetNumberOfRows();
    }
}
