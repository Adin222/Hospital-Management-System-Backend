using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repository.AppointmentRepository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<Appointment> AppointmentExists(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id) ?? throw new KeyNotFoundException("Appointment doesn't exist");
            return appointment;
        }

        public async Task DeleteAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            var apps = await _context.Appointments.ToListAsync();
            return apps;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            var app = await _context.Appointments.FindAsync(id) ?? throw new KeyNotFoundException("Appointment doesn't exist");
            return app;
        }

        public async Task<DateTime?> GetAppointmentDateById(int id)
        {
            var appointment = await _context.Appointments
                .Where(ap => ap.AppointmentID == id)
                .Select(ap => ap.AppointmentDateTime)
                .FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId)
        {
            var appointments = await _context.Appointments.Where(ap => ap.DoctorID == doctorId).ToArrayAsync();
            return appointments;
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}