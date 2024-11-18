using Hospital_Management_System.DTO.AppointmentDTOs;

namespace Hospital_Management_System.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<AppointmentResponse> CreateAppointmentAsync(AppointmentRequest req, int DocId, int RecId, int PatID);
        Task<IEnumerable<AppointmentDTO>> GetAllAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorIdAsync(int doctorId);
        Task<AppointmentResponse> GetAppointment(int id);

        Task DeleteAppointmentAsync(int id);
        Task UpdateAppointmentAsync(AppointmentUpdate req, int id);
    }
}
