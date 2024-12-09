using Hospital_Management_System.Services.PatientInformationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.PatientInformationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientInformationController : ControllerBase
    {
        private readonly IPatientInformationService _patientInformationService;
        public PatientInformationController(IPatientInformationService patientInformationService)
        {
            _patientInformationService = patientInformationService;
        }

        [HttpPut("allergy/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PutAllergyStatus(int patientId)
        {
            await _patientInformationService.UpdateAllergyState(patientId);
            return Ok("Allergy has been successfully updated");
        }

        [HttpPut("illness/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PutIllnessStatus(int patientId)
        {
            await _patientInformationService.UpdateIllnessState(patientId);
            return Ok("Illness has been successfully updated");
        }

        [HttpPut("medication/{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> PutMedicationStatus(int patientId)
        {
            await _patientInformationService.UpdateMedicationState(patientId);
            return Ok("Medication has been successfully updated");
        }
    }
}
