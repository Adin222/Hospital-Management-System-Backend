using Hospital_Management_System.DTO.VaccineDTOs;

namespace Hospital_Management_System.Services.VaccineServices
{
    public interface IVaccineService
    {
        public Task CreateVaccine(VaccineRequest request);
        public Task<ICollection<VaccineResponse>> GetAllVaccines();
    }
}
