namespace Hospital_Management_System.DTO.UserDTOs
{
    public class UserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required string PhoneNumber { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public string? DepartmentName { get; set; }
        public required DateTime EmploymentDate { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
