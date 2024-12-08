using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.Mappers.AllergyMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.AllergyRepository;

namespace Hospital_Management_System.Services.AllergyServices
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;
        public AllergyService(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task CreateAllergy(AllergyRequest request)
        {
            var allergy = new Allergy
            {
                AllergyName = request.AllergyName,
            };
            await _allergyRepository.AddAllergy(allergy);
        }

        public async Task<IEnumerable<AllergyResponse>> GetAllAllergies()
        {
            var allergies = await _allergyRepository.GetAllAllergies();
            var response = allergies.Select(allergy => allergy.ToAllergyDto());
            return response;
        }

        public async Task<IEnumerable<AllergyResponse>> GetAllAllergiesAsync(int patientId)
        {
            var allergies = await _allergyRepository.GetAllPatientAllergies(patientId);

            var response = allergies.Select(allergy => allergy.ToAllergyDto());

            return response;
        }
    }
}
