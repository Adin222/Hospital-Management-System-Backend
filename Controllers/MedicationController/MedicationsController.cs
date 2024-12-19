using Hospital_Management_System.DTO.MedicationDTOs;
using Hospital_Management_System.Services.MedicationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.MedicationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet("{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllPatientMedications(int patientId)
        {
            var medications = await _medicationService.GetAllMedicationsAsync(patientId);
            return Ok(medications);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateMedication([FromBody] MedicationRequest request)
        {
            await _medicationService.CreateMedication(request);
            return Ok("Medication successfully created");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllMedications()
        {
            var response = await _medicationService.GetAllMedicationsAsync();
            return Ok(response);
        }

        [HttpGet("unassigned/{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllUnassignedMedication(int patientId)
        {
            var response = await _medicationService.GetUnassignedMedication(patientId);
            return Ok(response);
        }

        [HttpPost("medication/{patientId}")]
        [Authorize]
        public async Task<IActionResult> AddPatientMedication([FromBody] MedicationRequest request, int patientId)
        {
            await _medicationService.AddNewPatientMedicationAsync(request, patientId);
            return Ok("Patient medication successfully added");
        }
    }
}
