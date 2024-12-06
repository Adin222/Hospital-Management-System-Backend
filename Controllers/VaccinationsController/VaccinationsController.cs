using Hospital_Management_System.DTO.PatientVaccineDTOs;
using Hospital_Management_System.Services.PatientVaccineServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.VaccinationsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinationsController : ControllerBase
    {
        private readonly IPatientVaccineService _patientVaccineService;

        public VaccinationsController(IPatientVaccineService patientVaccineService)
        {
            _patientVaccineService = patientVaccineService;
        }

        [HttpGet("{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllVaccinations(int patientId)
        {
            var response = await _patientVaccineService.GetPatientVaccinationsAsync(patientId);
            return Ok(response);
        }

        [HttpPost("{patientId}")]
        [Authorize]
        public async Task<IActionResult> CreatePatientVaccinations([FromBody] IEnumerable<PatientVaccineRequest> vaccinations, int patientId)
        {
            await _patientVaccineService.CreatePatientVaccinations(vaccinations, patientId);
            return Ok("Vaccinations successfully saved");
        }
    }
}
