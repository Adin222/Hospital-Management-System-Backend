using Hospital_Management_System.DTO.AppointmentDTOs;
using Hospital_Management_System.Mappers.AppointmentMappers;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository.AppointmentRepository;
using Hospital_Management_System.Repository.PatientRepository;
using Hospital_Management_System.Repository.UserRepository;

namespace Hospital_Management_System.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUserRepository userRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        public async Task<AppointmentDTO> CreateAppointmentAsync(AppointmentRequest req, int DocId, int RecId, int PatId)
        {
            await _patientRepository.PatientExists(PatId);
            await _userRepository.DoctorExists(DocId);

            if(await _userRepository.ReceptionistExists(RecId) != 3)
            {
                throw new KeyNotFoundException("Receptionist doesn't exist");
            }

            var appointment = new Appointment(req, DocId, PatId, RecId);

            var patient = await _patientRepository.GetPatientByID(PatId);

            if (patient.JMBG != req.JMBG)
            {
                throw new ApplicationException("JMBG is not valid");
            }

            var response = appointment.ToAppointmentDto();

            await _appointmentRepository.AddAppointmentAsync(appointment);
            return response;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();
            var response = appointments.Select(appointment => appointment.ToAppointmentDto()).ToList();

            return response;
        }


        public async Task<AppointmentDTO> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);

            var response = appointment.ToAppointmentDto();

            return response;
        }
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            await _appointmentRepository.DeleteAppointment(appointment);
        }

        public async Task UpdateAppointmentAsync(AppointmentUpdate req, int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);


            if (req.AppointmentDate.HasValue)
            {
                appointment.AppointmentDateTime = req.AppointmentDate.Value;
            }
            if (!string.IsNullOrEmpty(req.Status))
            {
                appointment.Status = req.Status;
            }
            appointment.UpdatedAt = DateTime.UtcNow;
            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

            var response = appointments.Select(appointment => appointment.ToAppointmentDto()).ToList();

            return response;
        }
    }
}
