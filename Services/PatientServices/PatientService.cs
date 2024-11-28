using Hospital_Management_System.DTO.PatientDTOs;
using Hospital_Management_System.Mappers.PatientMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.PatientRepository;

namespace Hospital_Management_System.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
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
