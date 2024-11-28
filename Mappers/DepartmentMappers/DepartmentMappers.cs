using Hospital_Management_System.DTO.DepartmentDTOs;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mappers.DepartmentMappers
{
    public static class DepartmentMappers
    {
        public static DepartmentDTO ToDepartmentDto(this Department department)
        {
            return new DepartmentDTO
            {
                Id = department.DepartmentID,
                DepartmentName = department.DepartmentName,
            };
        }
    }
}
