using Hospital_Management_System.DTO.RecordDTOs;
using Hospital_Management_System.Models;
using System.IO;

namespace Hospital_Management_System.Mappers.RecordMappers
{
    public static class RecordMappers
    {
        public static RecordResponse ToRecordResponseDto(this MedicalRecord record)
        {
            return new RecordResponse
            {
               Id = record.RecordID,
               PatientId = record.PatientID,
               DoctorId = record.DoctorID,
               AppointmentId = record.AppointmentID,
               Notes = record.Notes,
               Prescription = record.Prescription,
               DoctorName = record.Doctor.FirstName,
               DoctorLastName = record.Doctor.LastName,
               ReasonForVisit = record.Appointment.ReasonForVisit,
               Quantity = record.Quantity,
               Duration = record.Duration,
               Diagnosis = record.Diagnosis,
               CreatedAt = record.CreatedAt,
               UpdatedAt = record.UpdatedAt
            };
        }
    }
}
