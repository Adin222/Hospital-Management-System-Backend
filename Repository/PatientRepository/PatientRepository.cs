﻿using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.PatientRepository
{
    public class PatientRepository : IPatientRepository
    {
        private ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients ?? [];
        }


        public async Task<Patient> GetPatientByID(int id)
        {
           var patient = await _context.Patients.FindAsync(id) ?? throw new KeyNotFoundException("Patient doesn't exist");
           return patient;
        }

        public async Task<string> GetPatientNameById(int id)
        {
            var name = await _context.Patients
                .Where(p => p.PatientID == id)
                .Select(p => p.FirstName)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient doesn't exist");
            return name;
        }

        public async Task<Patient> PatientExists(int id)
        {
            var patient = await _context.Patients.FindAsync(id) ?? throw new KeyNotFoundException("Patient doesn't exist");
            return patient;
        }

        public async Task<bool> PatientExistsAsync(string email)
        {
            var patient = await _context.Patients.AnyAsync(u => u.Email == email);
            if (patient == true) throw new ApplicationException("Patient does");
            return false;
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
