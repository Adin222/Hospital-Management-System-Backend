using Hospital_Management_System.DTO.AppointmentDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.AppointmentMappers
{
    public static class AppointmentMappers
    {
        public static AppointmentDTO ToAppointmentDto(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.AppointmentID,
                DoctorId = appointment.DoctorID,
                ReceptionistId = appointment.ReceptionistID,
                PatientId = appointment.PatientID,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                AppointmentDate = appointment.AppointmentDateTime,
                SSN = appointment.Patient?.JMBG,
                FirstName = appointment.Patient?.FirstName,
                LastName = appointment.Patient?.LastName
            };
        }
    }
}
