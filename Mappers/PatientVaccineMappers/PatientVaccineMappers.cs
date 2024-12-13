using Hospital_Management_System.DTO.PatientVaccineDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.PatientVaccineMappers
{
    public static class PatientVaccineMappers
    {
        public static PatientVaccineResponse ToPatientVaccineDto(this PatientVaccine patientVaccine)
        {
            return new PatientVaccineResponse
            {
                PatientId = patientVaccine.PatientId,
                VaccineId = patientVaccine.VaccineId,
                VaccineName = patientVaccine.Vaccine.VaccineName,
                Status = patientVaccine.Status,
            };
        }
    }
}
