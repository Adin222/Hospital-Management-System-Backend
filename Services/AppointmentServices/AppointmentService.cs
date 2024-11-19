using Hospital_Management_System.DTO.AppointmentDTOs;
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
        public async Task<AppointmentResponse> CreateAppointmentAsync(AppointmentRequest req, int DocId, int RecId, int PatId)
        {
            await _patientRepository.PatientExists(PatId);
            await _userRepository.DoctorExists(DocId);
            if(await _userRepository.ReceptionistExists(RecId) != 3)
            {
                throw new KeyNotFoundException("Receptionist doesn't exist");
            }

            var appointment = new Appointment
            {
                DoctorID = DocId,
                ReceptionistID = RecId,
                PatientID = PatId,
                AppointmentDateTime = req.AppointmentDate,
                ReasonForVisit = req.ReasonForVisit,
                Status = req.Status,
                PatientJMBG = req.JMBG
            };

            var doctorName = await _userRepository.GetDoctorNameByDoctorId(DocId);
            var patient = await _patientRepository.GetPatientByID(PatId);
            var receptionist = await _userRepository.GetUserNameById(appointment.ReceptionistID);

            if (patient.JMBG != req.JMBG)
            {
                throw new ApplicationException("JMBG is not valid");
            }

            var response = new AppointmentResponse
            {
                Id = appointment.AppointmentID,
                DoctorName = doctorName,
                ReceptionistName = receptionist,
                PatientName = patient.FirstName,
                ReasonForVisit = req.ReasonForVisit,
                Status = req.Status,
                Reservation = appointment.AppointmentDateTime
            };
            await _appointmentRepository.AddAppointmentAsync(appointment);
            return response;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();
            var response = appointments.Select(appointment => new AppointmentDTO
            {
                Id = appointment.AppointmentID,
                DoctorId = appointment.DoctorID,
                ReceptionistId = appointment.ReceptionistID,
                PatientId = appointment.PatientID,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                AppointmentDate = appointment.AppointmentDateTime
            });

            return response;
        }


        public async Task<AppointmentResponse> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);

            var doctorName = await _userRepository.GetDoctorNameByDoctorId(appointment.DoctorID);
            var patient = await _patientRepository.GetPatientNameById(appointment.PatientID);
            var receptionist = await _userRepository.GetUserNameById(appointment.ReceptionistID);

            var response = new AppointmentResponse
            {
                Id = appointment.AppointmentID,
                DoctorName = doctorName,
                ReceptionistName = receptionist,
                PatientName = patient,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                Reservation = appointment.AppointmentDateTime
            };
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
            if (!string.IsNullOrEmpty(req.ReasonForVisit))
            {
                appointment.ReasonForVisit = req.ReasonForVisit;
            }
            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

            var response = appointments.Select(appointment => new AppointmentDTO
            {
                Id = appointment.AppointmentID,
                DoctorId = appointment.DoctorID,
                ReceptionistId = appointment.ReceptionistID,
                PatientId = appointment.PatientID,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                AppointmentDate = appointment.AppointmentDateTime
            });
            return response;
        }
    }
}
