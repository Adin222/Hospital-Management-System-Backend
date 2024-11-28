using Hospital_Management_System.DTO.PatientDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.PatientMappers
{
    public static class PatientMappers
    {
        public static PatientDto ToPatientDto(this Patient pat)
        {
            return new PatientDto
            {
                Id = pat.PatientID,
                FirstName = pat.FirstName,
                LastName = pat.LastName,
                DateOfBirth = pat.DateOfBirth,
                Address = pat.Address,
                Email = pat.Email,
                PhoneNumber = pat.PhoneNumber,
                City = pat.City,
                Country = pat.Country,
                Education = pat.Education,
                JMBG = pat.JMBG,
                CreatedAt = pat.CreatedAt
            };
        }
    }
}
