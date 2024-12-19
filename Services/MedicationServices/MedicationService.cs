using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.Mappers.MedicationMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.MedicationRepository;
using Hospital_Management_System.Repository.PatientRepository;

namespace Hospital_Management_System.Services.MedicationServices
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IPatientRepository _patientRepository;
        public MedicationService(IMedicationRepository medicationRepository, IPatientRepository patientRepository)
        {
            _medicationRepository = medicationRepository;
            _patientRepository = patientRepository;
        }

        public async Task AddNewPatientMedicationAsync(MedicationRequest request, int patientId)
        {
            var medication = await _medicationRepository.GetMedicationById(request.MedicationId);
            var patient = await _patientRepository.GetPatientByID(patientId);

            await _medicationRepository.ConnectMedicationAndPatient(patient, medication);
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

        public async Task<ICollection<MedicationResponse>> GetUnassignedMedication(int patientId)
        {
            var medication = await _medicationRepository.GetAllMedication();

            var patientMedication = await _medicationRepository.GetAllMedicationByPatientId(patientId);

            var patientMedicationIds = new HashSet<int>(patientMedication.Select(medication => medication.MedicationId));

            var unassignedMedication = medication
                .Where(medication => !patientMedicationIds.Contains(medication.MedicationId))
                .Select(medication => medication.ToMedicationDto())
                .ToList();

            return unassignedMedication;
        }

        public async Task RemovePatientMedicationAsync(MedicationRequest request, int patientId)
        {
            var medication = await _medicationRepository.GetMedicationById(request.MedicationId);
            var patient = await _patientRepository.GetPatientByID(patientId);

            await _medicationRepository.DisconnectMedicationAndPatient(patient, medication);
        }
    }
}
