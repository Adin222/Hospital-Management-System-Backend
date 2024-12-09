using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.Mappers.MedicationMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.MedicationRepository;

namespace Hospital_Management_System.Services.MedicationServices
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public async Task CreateMedication(MedicationRequest request)
        {
            var medication = new Medication
            {
                MedicationName = request.MedicationName
            };
                
            await _medicationRepository.AddMedication(medication);
        }

        public async Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync(int patientId)
        {
            var medications = await _medicationRepository.GetAllMedicationByPatientId(patientId);

            var response = medications.Select(medication => medication.ToMedicationDto());

            return response;
        }

        public async Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync()
        {
            var medications = await _medicationRepository.GetAllMedication();

            var response = medications.Select(medication => medication.ToMedicationDto());

            return response;
        }
    }
}
