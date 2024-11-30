﻿using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.PatientVaccineRepository
{
    public class PatientVaccineRepository : IPatientVaccineRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientVaccineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPatientVaccinations(IEnumerable<PatientVaccine> patientVaccinations)
        {
            _context.PatientVaccines.AddRange(patientVaccinations);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientVaccine>> GetAllVaccinationsByPatientId(int patientId)
        {
            var vaccinations = await _context.PatientVaccines
                .Where(pt => pt.PatientId == patientId)
                .ToListAsync();
            return vaccinations;
        }
    }
}
