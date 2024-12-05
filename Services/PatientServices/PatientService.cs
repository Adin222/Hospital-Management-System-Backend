using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.DTO.PatientDTOs;
using Hospital_Management_System.Mappers.PatientMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.AllergyRepository;
using Hospital_Management_System.Repository.IllnessRepository;
using Hospital_Management_System.Repository.MedicationRepository;
using Hospital_Management_System.Repository.PatientRepository;

namespace Hospital_Management_System.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IIllnessRepository _illnessRepository;
        private readonly IAllergyRepository _allergyRepository;
        private readonly IMedicationRepository _medicationRepository;

        public PatientService(IPatientRepository patientRepository, IIllnessRepository illnessRepository, IMedicationRepository medicationRepository, IAllergyRepository allergyRepository)
        {
            _patientRepository = patientRepository;
            _illnessRepository = illnessRepository;
            _medicationRepository = medicationRepository;
            _allergyRepository = allergyRepository;
        }

        public async Task<PatientDto> CreatePatientAsync(PatientDto patient)
        {
            await _patientRepository.PatientExistsAsync(patient.Email);
            
            var CreatedPatient = new Patient(patient);
            
            var pat = await _patientRepository.AddPatientAsync(CreatedPatient);

            var response = pat.ToPatientDto();

            return response;
        }

        public async Task DeletePatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByID(id);
            await _patientRepository.DeletePatient(patient);

        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();

            var response = patients.Select(patient => patient.ToPatientDto()).ToList();

            return response;
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByID(id);

            var response = patient.ToPatientDto();

            return response;
        }

        public async Task<PatientDto> GetPatientBySSNAsync(string ssn)
        {
            var patient = await _patientRepository.GetPatientBySSN(ssn);
            var response = patient.ToPatientDto();

            return response;
        }

        public async Task RegisterPatientAllergy(IEnumerable<AllergyRequest> requests, int patientId)
        {
            var patient = await _patientRepository.GetPatientIncludesAllergy(patientId);

            foreach(var request in requests)
            {
                var allergy = await _allergyRepository.GetAllergyById(request.AllergyId);
                await _allergyRepository.ConnectAllergy(patient, allergy);
            }
        }

        public async Task RegisterPatientChronicIllness(IEnumerable<IllnessRequest> requests, int patientId)
        {
            var patient = await _patientRepository.GetPatientIncludesIllness(patientId);

            foreach (var req in requests)
            {
                var illness = await _illnessRepository.GetIllnessById(req.IllnessId);
                await _illnessRepository.ConnectIllness(patient, illness);
            }
        }

        public async Task RegisterPatientMedication(IEnumerable<MedicationRequest> requests, int patientId)
        {
            var patient = await _patientRepository.GetPatientIncludesMedication(patientId);

            foreach(var req in requests)
            {
                var medication = await _medicationRepository.GetMedicationById(req.MedicationId);
                await _medicationRepository.ConnectMedicationAndPatient(patient, medication);
            }
        }

        public async Task UpdatePatientByIdAsync(int id, PatientUpdateDto patientDto)
        {
            var patient = await _patientRepository.GetPatientByID(id);

            if (!string.IsNullOrEmpty(patientDto.FirstName))
            {
                patient.FirstName = patientDto.FirstName;
            }
            if (!string.IsNullOrEmpty(patientDto.LastName))
            {
                patient.LastName = patientDto.LastName;
            }
            if (!string.IsNullOrEmpty(patientDto.PhoneNumber))
            {
                patient.PhoneNumber = patientDto.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(patientDto.Email))
            {
                patient.Email = patientDto.Email;
            }
            await _patientRepository.UpdatePatient(patient);
        }
    }
}
