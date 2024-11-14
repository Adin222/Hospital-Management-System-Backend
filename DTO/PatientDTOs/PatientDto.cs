namespace Hospital_Management_System.DTO.PatientDTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string Education { get; set; }
        public required string JMBG { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
