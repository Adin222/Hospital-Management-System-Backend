using Hospital_Management_System.DTO.UserDTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class User
    {
        public User() { }

        public User(UserDto userDto, string hashedPassword, int roleId)
        {
            FirstName = userDto.FirstName;
            LastName = userDto.LastName;
            PasswordHash = hashedPassword;
            Email = userDto.Email;
            CreatedAt = DateTime.UtcNow;
            EmploymentDate = userDto.EmploymentDate;
            PhoneNumber = userDto.PhoneNumber;
            Country = userDto.Country;
            City = userDto.City;
            RoleID = roleId;
            DateOfBirth = userDto.DateOfBirth;
        }

        [Key]
        public int UserID { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(1000)]
        public string PasswordHash { get; set; }
        [MaxLength(25)]
        public string PhoneNumber { get; set; }
        [MaxLength(25)]
        public string DateOfBirth { get; set; }
        [MaxLength(25)]
        public string Country { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Doctor Doctor { get; set; }
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Chat> Chats { get; set; } = [];
    }
}
