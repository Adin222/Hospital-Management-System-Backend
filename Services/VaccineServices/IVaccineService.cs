using Hospital_Management_System.DTO.VaccineDTOs;

namespace Hospital_Management_System.Services.VaccineServices
{
    public interface IVaccineService
    {
        Task CreateVaccine(VaccineRequest request);
        Task<ICollection<VaccineResponse>> GetAllVaccines();
    }
}
