using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.AppointmentRepository
{
    public interface IAppointmentRepository
    {
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId);
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<DateTime?> GetAppointmentDateById(int id);
        Task<Appointment> AppointmentExists(int id);
    }
}
