using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.AllergyMappers
{
    public static class AllergyMappers
    {
        public static AllergyResponse ToAllergyDto(this Allergy allergy)
        {
            return new AllergyResponse
            {
                AllergyId = allergy.AllergyId,
                AllergyName = allergy.AllergyName,
            };
        }
    }
}
