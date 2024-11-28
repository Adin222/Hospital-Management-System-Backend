using Hospital_Management_System.DTO.DoctorDTOs;
using Hospital_Management_System.Mappers.DoctorMappers;
using Hospital_Management_System.Repository.DoctorRepository;

namespace Hospital_Management_System.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDTO> GetDoctorAsync(int doctorId)
        {
           var doctor = await _doctorRepository.GetDoctorByDoctorId(doctorId);
           var response = doctor.ToDoctorDto();

           return response;
        }

        public async Task<int> GetDoctorIdByUserIdAsync(int userId)
        {
            var doctorId = await _doctorRepository.GetDoctorIdByUserId(userId);
            return doctorId;
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecializationAsync(string specialization)
        {
            var doctors = await _doctorRepository.GetDoctorsBySpecialization(specialization);

            var response = doctors.Select(doctor => doctor.ToDoctorDto()).ToList();

            return response;
        }
    }
}
