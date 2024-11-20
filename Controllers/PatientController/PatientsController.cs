using Hospital_Management_System.DTO.PatientDTOs;
using Hospital_Management_System.Services.PatientServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.PatientController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("patient")]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> Create([FromBody] PatientDto patientBody)
        {
              var patient = await _patientService.CreatePatientAsync(patientBody);
              return Ok(patient);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> GetAllPatients()
        {
        
              var patients = await _patientService.GetAllPatientsAsync();
              return Ok(patients);
        }
        [HttpGet("patient/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,RECEPTIONIST")]
        public async Task<IActionResult> GetPatient(int id)
        {
             var patient = await _patientService.GetPatientByIdAsync(id);
             return Ok(patient);
        }

        [HttpDelete("patient/{id}")]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> DeletePatient(int id)
        {
              await _patientService.DeletePatientByIdAsync(id);
              return Ok("Patient has been successfully deleted");
        }
        [HttpPut("patient/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,RECEPTIONIST")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientUpdateDto body)
        {
            
               await _patientService.UpdatePatientByIdAsync(id, body);
               return Ok("Patient has been successfully updated");
        }

        [HttpGet("patient/ssn/{ssn}")]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> GetPatientBySSN(string ssn)
        {
            var patient = await _patientService.GetPatientBySSNAsync(ssn);
            return Ok(patient);
        }
    }
}
