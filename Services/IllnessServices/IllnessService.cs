using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.Mappers.IllnessMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.IllnessRepository;
using Hospital_Management_System.Repository.PatientRepository;

namespace Hospital_Management_System.Services.IllnessServices
{
    public class IllnessService : IIllnessService
    {
        private readonly IIllnessRepository _illnessRepository;
        private readonly IPatientRepository _patientRepository;

        public IllnessService(IIllnessRepository illnessRepository, IPatientRepository patientRepository)
        {
            _illnessRepository = illnessRepository;
            _patientRepository = patientRepository;
        }

        public async Task AddNewPatientIllnessAsync(IllnessRequest request, int patientId)
        {
            var illness = await _illnessRepository.GetIllnessById(request.IllnessId);

            var patient = await _patientRepository.GetPatientByID(patientId);

            await _illnessRepository.ConnectIllness(patient, illness);
            
        }

        public async Task CreateIllness(IllnessRequest illness)
        {
            var response = new Illness
            {
                IllnessName = illness.IllnessName
            };
            await _illnessRepository.AddIllness(response);
        }

        public async Task<IEnumerable<IllnessResponse>> GetAllChronicIllnessesAsync(int patientId)
        {
            var illnesses = await _illnessRepository.GetAllIllnessesByPatientId(patientId);

            var response = illnesses.Select(illness => illness.ToIllnessDto());

            return response;
        }

        public async Task<IEnumerable<IllnessResponse>> GetAllIllnesses()
        {
            var Illnesses = await _illnessRepository.GetAllIllnesses();

            var response = Illnesses.Select(illness => illness.ToIllnessDto());

            return response;
        }

        public async Task<ICollection<IllnessResponse>> GetUnassignedIllnesses(int patientId)
        {
            var illnesses = await _illnessRepository.GetAllIllnesses();

            var patientIllnesses = await _illnessRepository.GetAllIllnessesByPatientId(patientId);

            var patientIllnessesId = new HashSet<int>(patientIllnesses.Select(pi => pi.IllnessId));

            var unassignedIllnesses = illnesses
                .Where(illness => !patientIllnessesId.Contains(illness.IllnessId))
                .Select(illness => illness.ToIllnessDto())
                .ToList();

            return unassignedIllnesses;
        }
    }
}
