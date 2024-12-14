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

        [HttpGet("{doctorId}/{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetAllRecords(int doctorId, int patientId)
        {
            var response = await _recordService.GetMedicalRecordsByDoctorAndPatient(doctorId, patientId);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> GetAllRecords()
        {
             var records = await _recordService.GetAllMedicalRecordsAsync();
             return Ok(records);
        }

        [HttpGet("{patientId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> GetAllRecordsOfPatient(int patientId)
        {
            var record = await _recordService.GetAllMedicalRecordsByPatientIdAsync(patientId);
            return Ok(record);
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
        public async Task<IActionResult> CreateRecord([FromBody] IEnumerable<RecordRequest> request, int patientId, int doctorId, int appointmentId)
        {
              await _recordService.CreateRecord(request, patientId, doctorId, appointmentId);
              return Ok("Medical record has been successfully created");
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
