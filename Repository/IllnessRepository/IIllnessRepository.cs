using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.IllnessRepository
{
    public interface IIllnessRepository
    {
        Task AddIllness(Illness illness);
        Task<Illness> GetIllnessById(int illnessId);
        Task ConnectIllness(Patient patient, Illness illness);
        Task<ICollection<Illness>> GetAllIllnessesByPatientId(int patientId);
    }
}
