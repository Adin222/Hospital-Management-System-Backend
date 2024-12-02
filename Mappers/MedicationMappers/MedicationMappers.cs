using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.MedicationMappers
{
    public static class MedicationMappers
    {
        public static MedicationResponse ToMedicationDto(this Medication medication)
        {
            return new MedicationResponse
            {
                MedicationId = medication.MedicationId,
                MedicationName = medication.MedicationName
            };
        }
    }
}
