using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);
        Task<int> GetDoctorIdByUserId(int  userId);
    }
}
