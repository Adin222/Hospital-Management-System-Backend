using Hospital_Management_System.DTO.RecordDTOs;
using Hospital_Management_System.Services.RecordServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.RecordController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> GetAllRecords()
        {
             var records = await _recordService.GetAllMedicalRecordsAsync();
             return Ok(records);
        }

        [HttpGet("record/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> GetRecordById(int id)
        {

            var record = await _recordService.GetMedicalRecordByIdAsync(id);
            return Ok(record);   
        }

        [HttpDelete("record/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
              await _recordService.DeleteMedicalRecordAsync(id);
              return Ok("Medical record has been successfully deleted");
        }
        [HttpPost("record/{patientId}/{doctorId}/{appointmentId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> CreateRecord([FromBody] RecordRequest req, int patientId, int doctorId, int appointmentId)
        {
              var record = await _recordService.CreateRecord(req, patientId, doctorId, appointmentId);
              return Ok(record);
        }

        [HttpPut("record/{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> UpdateRecord([FromBody] RecordRequest req, int id)
        {
              await _recordService.UpdateMedicalRecordByIdAsync(req, id);
              return Ok("Medical record has been successfully updated");
        }
    }
}
