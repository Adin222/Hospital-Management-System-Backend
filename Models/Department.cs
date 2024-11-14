using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [MaxLength(50)]
        public required string DepartmentName { get; set; }

        public required ICollection<Doctor_Department> DoctorDepartments { get; set; }
    }
}
