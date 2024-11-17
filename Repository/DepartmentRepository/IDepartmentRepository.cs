using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repository.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}
