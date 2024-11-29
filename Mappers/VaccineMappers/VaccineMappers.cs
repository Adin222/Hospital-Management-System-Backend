using Hospital_Management_System.DTO.VaccineDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.VaccineMappers
{
    public static class VaccineMappers
    {
        public static VaccineResponse ToVaccineDto(this Vaccine vaccine)
        {
            return new VaccineResponse 
            { 
                Id = vaccine.VaccineId, 
                VaccineName = vaccine.VaccineName 
            };
        }
    }
}
