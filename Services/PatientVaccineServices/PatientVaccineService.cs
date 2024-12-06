using Hospital_Management_System.DTO.PatientVaccineDTOs;
using Hospital_Management_System.Mappers.PatientVaccineMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.PatientRepository;
using Hospital_Management_System.Repository.PatientVaccineRepository;
using Hospital_Management_System.Repository.VaccineRepository;

namespace Hospital_Management_System.Services.PatientVaccineServices
{
    public class PatientVaccineService : IPatientVaccineService
    {
        private readonly IPatientVaccineRepository _patientVaccineRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IVaccineRepository _vaccineRepository;

        public PatientVaccineService(IPatientVaccineRepository patientVaccineRepository, IPatientRepository patientRepository, IVaccineRepository vaccineRepository)
        {
            _patientVaccineRepository = patientVaccineRepository;
            _patientRepository = patientRepository;
            _vaccineRepository = vaccineRepository;
        }

        public async Task CreatePatientVaccinations(IEnumerable<PatientVaccineRequest> patientVaccineRequests, int patientId)
        {
            var exists = await _patientVaccineRepository.PatientVaccineExists(patientId);

            if (!exists)
            {
                var patientExists = await _patientRepository.PatientExistsAsync(patientId);

                var vaccinesRows = await _vaccineRepository.GetNumberOfRows();

                if (vaccinesRows != patientVaccineRequests.Count())
                {
                    throw new InvalidOperationException("Request body has to be the same size as the number of all vaccines in the database.");
                }

                if (!patientExists) throw new KeyNotFoundException("Patient doesn't exist");

                foreach (var request in patientVaccineRequests)
                {
                    var vaccineExists = await _vaccineRepository.VaccineExistsAsync(request.VaccineId);
                    if (!vaccineExists)
                    {
                        throw new KeyNotFoundException("Vaccine doesn't exist");
                    }
                }

                var patientVaccines = patientVaccineRequests.Select(patientVaccine => new PatientVaccine
                {
                    PatientId = patientId,
                    VaccineId = patientVaccine.VaccineId,
                    Status = patientVaccine.Status
                });

                await _patientVaccineRepository.AddPatientVaccinations(patientVaccines);
            }
            else
            {
                throw new ApplicationException("Patient already has vaccination information.");
            }
           
        }

        public async Task<IEnumerable<PatientVaccineResponse>> GetPatientVaccinationsAsync(int patientId)
        {
            var patientVaccines = await _patientVaccineRepository.GetAllVaccinationsByPatientId(patientId);

            var response = patientVaccines.Select(patientVaccine => patientVaccine.ToPatientVaccineDto());
            return response;
        }
    }
}
