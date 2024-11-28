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
               Quantity = record.Quantity,
               Duration = record.Duration,
               Diagnosis = record.Diagnosis,
               CreatedAt = record.CreatedAt,
               UpdatedAt = record.UpdatedAt
            };
        }
    }
}
