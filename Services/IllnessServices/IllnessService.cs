using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.Mappers.IllnessMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.IllnessRepository;

namespace Hospital_Management_System.Services.IllnessServices
{
    public class IllnessService : IIllnessService
    {
        private readonly IIllnessRepository _illnessRepository;

        public IllnessService(IIllnessRepository illnessRepository)
        {
            _illnessRepository = illnessRepository;
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
    }
}
