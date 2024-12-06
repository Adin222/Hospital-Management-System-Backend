using Hospital_Management_System.DTO.AppointmentDTOs;
using Hospital_Management_System.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.AppointmentController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("appointment/{doctorId}/{receptionistId}/{patientId}")]
        [Authorize(Roles = "RECEPTIONIST,ADMIN")]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentRequest req, int doctorId, int receptionistId, int patientId)
        {
               await _appointmentService.CreateAppointmentAsync(req, doctorId, receptionistId, patientId);
               return Ok("Appointment has been successfully created");
        }

        [HttpGet]
        [Authorize(Roles = "RECEPTIONIST,ADMIN")]
        public async Task<IActionResult> GetAllAppointments()
        {
               var appointments = await _appointmentService.GetAllAppointments();
               return Ok(appointments);
        }

        [HttpGet("{doctorId}")]
        [Authorize(Roles = "DOCTOR,ADMIN")]
        public async Task<IActionResult> GetAllAppointmentsOfDoctor(int doctorId)
        {
            var appointments = await _appointmentService.GetAllAppointmentsByDoctorIdAsync(doctorId);
            return Ok(appointments);
        }

        [HttpGet("appointment/{id}")]
        [Authorize(Roles = "RECEPTIONIST,ADMIN")]
        public async Task<IActionResult> GetAppointment(int id)
        {
       
               var appointment = await _appointmentService.GetAppointment(id);
               return Ok(appointment);
        }

        [HttpDelete("appointment/{id}")]
        [Authorize(Roles = "RECEPTIONIST,ADMIN")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
              await _appointmentService.DeleteAppointmentAsync(id);
              return Ok("Appointment has been successfully deleted");
        }

        [HttpPut("appointment/{id}")]
        [Authorize(Roles = "RECEPTIONIST,ADMIN,DOCTOR")]
        public async Task<IActionResult> UpdateAppointment([FromBody]AppointmentUpdate req, int id)
        {
              await _appointmentService.UpdateAppointmentAsync(req, id);
              return Ok("Appointment has been successfully updated");
        }
    }
}
