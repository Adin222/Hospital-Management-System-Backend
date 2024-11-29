using Hospital_Management_System.DTO.VaccineDTOs;
using Hospital_Management_System.Mappers.VaccineMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.VaccineRepository;

namespace Hospital_Management_System.Services.VaccineServices
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public async Task CreateVaccine(VaccineRequest request)
        {
            var vaccine = new Vaccine
            {
                VaccineName = request.VaccineName
            };
            await _vaccineRepository.AddVaccine(vaccine);
        }

        public async Task<ICollection<VaccineResponse>> GetAllVaccines()
        {
            var vaccines = await _vaccineRepository.GetAllVaccines();

            var response = vaccines.Select(vaccine => vaccine.ToVaccineDto()).ToList();

            return response;
        }
    }
}
