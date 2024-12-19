using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.Mappers.AllergyMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.AllergyRepository;
using Hospital_Management_System.Repository.PatientRepository;

namespace Hospital_Management_System.Services.AllergyServices
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IPatientRepository _patientRepository;
        public AllergyService(IAllergyRepository allergyRepository, IPatientRepository patientRepository)
        {
            _allergyRepository = allergyRepository;
            _patientRepository = patientRepository;
        }

        public async Task AddNewPatientAllergyAsync(AllergyRequest request, int patientId)
        {
            var allergy = await _allergyRepository.AllergyExists(request.AllergyId);
            var patient = await _patientRepository.GetPatientByID(patientId);

            await _allergyRepository.ConnectAllergy(patient, allergy);
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

        public async Task<ICollection<AllergyResponse>> GetUnassignedAllergies(int patientId)
        {
            var allAllergies = await _allergyRepository.GetAllAllergies();

            var allPatientAllergies = await _allergyRepository.GetAllPatientAllergies(patientId);

            var patientAllergyIds = new HashSet<int>(allPatientAllergies.Select(pa => pa.AllergyId));

            var response = allAllergies
                .Where(allergy => !patientAllergyIds.Contains(allergy.AllergyId))
                .Select(allergy => allergy.ToAllergyDto())
                .ToList();

            return response;
        }
    }
}
