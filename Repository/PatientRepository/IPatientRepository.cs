﻿using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.PatientRepository
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatientAsync(Patient patient);
        Task<bool> PatientExistsAsync(string email);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByID(int id);
        Task DeletePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task<string> GetPatientNameById(int id);
        Task<Patient> PatientExists(int id);
        Task<Patient> GetPatientBySSN(string ssn);
        Task<bool> PatientExistsAsync(int patientId);
        Task<bool> PatientVaccinationExists(int patientId);
        Task<bool> PatientMedicalRecordExists(int patientId);
        Task<Patient> GetPatientIncludesIllness(int patientId);
        Task<Patient> GetPatientIncludesMedication(int patientId);
        Task<Patient> GetPatientIncludesAllergy(int patientId);
    }
}
