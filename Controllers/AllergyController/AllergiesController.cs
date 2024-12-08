using Hospital_Management_System.DTO.AllergyDTOs;
using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.Services.AllergyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.AllergyController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyService _allergyService;
        public AllergiesController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateIllness([FromBody] AllergyRequest request)
        {
            await _allergyService.CreateAllergy(request);
            return Ok("Allergy has been successfully registered");
        }

        [HttpGet("{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllIllnesses(int patientId)
        {
            var response = await _allergyService.GetAllAllergiesAsync(patientId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAllergies()
        {
            var response = await _allergyService.GetAllAllergies();
            return Ok(response);
        }
    }
}
