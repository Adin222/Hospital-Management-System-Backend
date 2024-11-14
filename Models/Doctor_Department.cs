using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Doctor_Department
    {
        public int DoctorID { get; set; }

        [ForeignKey("DoctorID")]
        public Doctor Doctor { get; set; }

        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}
