using Hospital_Management_System.Repository.PatientInformationRepository;

namespace Hospital_Management_System.Services.PatientInformationServices
{
    public class PatientInformationService : IPatientInformationService
    {
        private readonly IPatientInformationRepository _patientInformationRepository;

        public PatientInformationService(IPatientInformationRepository patientInformationRepository)
        {
            _patientInformationRepository = patientInformationRepository;
        }

        public async Task UpdateAllergyState(int patientId)
        {
            var patientInformation = await _patientInformationRepository.GetPatientInfoById(patientId);

            patientInformation.Allergy = false;

            await _patientInformationRepository.UpdatePatientInformation(patientInformation);
        }

        public async Task UpdateIllnessState(int patientId)
        {
            var patientInformation = await _patientInformationRepository.GetPatientInfoById(patientId);

            patientInformation.ChronicIllness = false;

            await _patientInformationRepository.UpdatePatientInformation(patientInformation);
        }

        public async Task UpdateMedicationState(int patientId)
        {
            var patientInformation = await _patientInformationRepository.GetPatientInfoById(patientId);

            patientInformation.Medication = false;

            await _patientInformationRepository.UpdatePatientInformation(patientInformation);
        }
    }
}
