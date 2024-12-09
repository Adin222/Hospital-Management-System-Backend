using Hospital_Management_System.DTO.IllnessDTOs;
using Hospital_Management_System.Services.IllnessServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.IllnessController
{
    [ApiController]
    [Route("api/[controller]")]
    public class IllnessesController : ControllerBase
    {
        private readonly IIllnessService _illnessService;
        public IllnessesController(IIllnessService illnessService)
        {
            _illnessService = illnessService;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateIllness([FromBody] IllnessRequest request)
        {
            await _illnessService.CreateIllness(request);
            return Ok("Illness has been successfully registered");
        }

        [HttpGet("{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllIllnesses(int patientId)
        {
            var response = await _illnessService.GetAllChronicIllnessesAsync(patientId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllIllnesses()
        {
            var response = await _illnessService.GetAllIllnesses();
            return Ok(response);
        }
    }
}
