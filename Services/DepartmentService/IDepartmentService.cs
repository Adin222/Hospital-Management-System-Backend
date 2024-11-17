using Hospital_Management_System.DTO.DepartmentDTOs;

namespace Hospital_Management_System.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
    }
}
