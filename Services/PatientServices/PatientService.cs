using Hospital_Management_System.DTO.PatientDTOs;
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
            
            var CreatedPatient = new Patient 
            { 
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber, 
                City = patient.City,
                Country = patient.Country,
                Education = patient.Education,
                JMBG = patient.JMBG,
                CreatedAt = DateTime.UtcNow,
            };
            
            var pat = await _patientRepository.AddPatientAsync(CreatedPatient);

            var response = new PatientDto
            {
                Id = pat.PatientID,
                FirstName = pat.FirstName,
                LastName = pat.LastName,
                DateOfBirth = pat.DateOfBirth,
                Address = pat.Address,
                Email = pat.Email,
                PhoneNumber = pat.PhoneNumber,
                City = pat.City,
                Country = pat.Country,
                Education = pat.Education,
                JMBG = pat.JMBG,
                CreatedAt = pat.CreatedAt
            };

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

            var response = patients.Select(patient => new PatientDto
            {
                Id = patient.PatientID,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                City = patient.City,
                Country = patient.Country,
                Education = patient.Education,
                JMBG= patient.JMBG,
                CreatedAt = patient.CreatedAt,
            }).ToList();

            return response;
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByID(id);

            var response = new PatientDto
            {
                Id = patient.PatientID,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                City = patient.City,
                Country = patient.Country,
                Education = patient.Education,
                JMBG= patient.JMBG,
                CreatedAt = patient.CreatedAt,
            };
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
