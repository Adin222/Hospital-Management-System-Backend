using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.DTO.MedicationDTOs;
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

        [HttpPost("illness/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> RegisterPatientIllness([FromBody] IEnumerable<IllnessRequest> requests, int patientId)
        {
            await _patientService.RegisterPatientChronicIllness(requests, patientId);
            return Ok("Chronic illnesses successfully connected with patient");
        }

        [HttpPost("medication/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> RegisterPatientMedication([FromBody] IEnumerable<MedicationRequest> requests, int patientId)
        {
            await _patientService.RegisterPatientMedication(requests, patientId);
            return Ok("Medication successfully connected with patient");
        }

        [HttpPost("allergy/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> RegisterPatientAllergy([FromBody] IEnumerable<AllergyRequest> requests, int patientId)
        {
            await _patientService.RegisterPatientAllergy(requests, patientId);
            return Ok("Allergy successfully connected with patient");
        }

        [HttpGet("vaccination/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PatientVaccinationExists(int patientId)
        {
            var patient = await _patientService.PatientVaccinationExists(patientId);

            return Ok(patient);
        }

        [HttpGet("allergy/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PatientAllergyExists(int patientId)
        {
            var patient = await _patientService.PatientAllergyExists(patientId);

            return Ok(patient);
        }

        [HttpGet("illness/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PatientIllnessExists(int patientId)
        {
            var patient = await _patientService.PatientIllnessExists(patientId);

            return Ok(patient);
        }

        [HttpGet("medication/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PatientMedicationExists(int patientId)
        {
            var patient = await _patientService.PatientMedicationExists(patientId);

            return Ok(patient);
        }

        [HttpGet("patient/overview/{patientId}")]
        [Authorize]
        public async Task<IActionResult> PatientStatus(int patientId)
        {
            var vaccines = await _patientService.PatientVaccinationExists(patientId);
            var allergies = await _patientService.PatientAllergyExists(patientId);
            var illnesses = await _patientService.PatientIllnessExists(patientId);
            var medication = await _patientService.PatientMedicationExists(patientId);
            var response = vaccines && !allergies && !illnesses && !medication;

            return Ok(response);
        }
    }
}
