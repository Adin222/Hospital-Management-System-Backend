using Hospital_Management_System.Services.DepartmentService;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.DepartmentController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("department/{doctorId}")]
        [Authorize]
        public async Task<IActionResult> GetDepartment(int doctorId)
        {
            var response = await _departmentService.GetDepartmentAsync(doctorId);
            return Ok(response);
        }
    }
}
