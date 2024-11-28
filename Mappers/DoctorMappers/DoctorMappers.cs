using Hospital_Management_System.DTO.DoctorDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.DoctorMappers
{
    public static class DoctorMappers
    {
        public static DoctorDTO ToDoctorDto(this Doctor doctor)
        {
            return new DoctorDTO
            { 
                Id = doctor.DoctorID,
                FirstName = doctor.FirstName, 
                LastName = doctor.LastName 
            };
        }
    }
}
