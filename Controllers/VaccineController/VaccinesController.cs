using Hospital_Management_System.DTO.VaccineDTOs;
using Hospital_Management_System.Services.VaccineServices;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.VaccineController
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinesController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccinesController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllVaccines()
        {
            var vaccines = await _vaccineService.GetAllVaccines();
            return Ok(vaccines);
        }

        [HttpPost("vaccine")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateVaccine([FromBody] VaccineRequest body)
        {
            await _vaccineService.CreateVaccine(body);
            return Ok("Vaccine has been successfully created");
        }
    }
}
