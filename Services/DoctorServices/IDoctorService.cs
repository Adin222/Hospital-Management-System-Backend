using Hospital_Management_System.DTO.DoctorDTOs;

namespace Hospital_Management_System.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetDoctorByGetDoctorsBySpecializationAsync(string specialization);
    }
}
