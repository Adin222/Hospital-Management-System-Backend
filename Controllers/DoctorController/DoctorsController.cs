﻿using Hospital_Management_System.Services.DoctorServices;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.DoctorController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("doctor/{specialization}")]
        [Authorize(Roles = "ADMIN,RECEPTIONIST")]
        public async Task<IActionResult> GetAllDoctorsBySpecialization(string specialization)
        {
            var doctors = await _doctorService.GetDoctorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpGet("doctorId/{userId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> GetDoctorId(int userId)
        {
            var doctorId = await _doctorService.GetDoctorIdByUserIdAsync(userId);
            return Ok(doctorId);
        }
    }
}
