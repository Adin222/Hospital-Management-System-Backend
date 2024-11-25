using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Doctor_Department> DoctorDepartments { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor_Department>()
            .HasKey(dd => new { dd.DoctorID, dd.DepartmentID });

        modelBuilder.Entity<Doctor_Department>()
            .HasOne(dd => dd.Doctor)
            .WithMany(d => d.DoctorDepartments)
            .HasForeignKey(dd => dd.DoctorID);

        modelBuilder.Entity<Doctor_Department>()
            .HasOne(dd => dd.Department)
            .WithMany(d => d.DoctorDepartments)
            .HasForeignKey(dd => dd.DepartmentID);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleID);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Doctor)
            .WithOne(d => d.User)
            .HasForeignKey<Doctor>(d => d.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments) 
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientID) 
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.MedicalRecords)
            .WithOne(m => m.Patient) 
            .HasForeignKey(m => m.PatientID) 
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(c => c.Chats)
            .WithOne(c => c.User)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalRecord>()
            .HasOne(rc => rc.Appointment)
            .WithMany(r => r.MedicalRecords)
            .HasForeignKey(r => r.AppointmentID)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);  
    }
}
