using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.IllnessMappers
{
    public static class IllnessMapper
    {
        public static IllnessResponse ToIllnessDto(this Illness illness)
        {
            return new IllnessResponse
            {
                IllnessId = illness.IllnessId,
                IllnessName = illness.IllnessName,
            };
        }
    }
}
