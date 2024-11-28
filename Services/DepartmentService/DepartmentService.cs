using Hospital_Management_System.DTO.DepartmentDTOs;
using Hospital_Management_System.Mappers.DepartmentMappers;
using Hospital_Management_System.Repository.DepartmentRepository;

namespace Hospital_Management_System.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            var response = departments.Select(department => department.ToDepartmentDto()).ToList();
            return response;
        }

        public async Task<DepartmentDTO> GetDepartmentAsync(int doctorId)
        {
            var department = await _departmentRepository.GetDepartmentById(doctorId);
            var response = department.ToDepartmentDto();
            return response;
        }
    }
}
