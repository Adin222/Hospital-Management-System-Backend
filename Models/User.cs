using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(25)]
        public required string FirstName { get; set; }

        [MaxLength(25)]
        public required string LastName { get; set; }

        [MaxLength(255)]
        public required string Email { get; set; }

        [MaxLength(1000)]
        public required string PasswordHash { get; set; }
        [MaxLength(25)]
        public required string PhoneNumber { get; set; }
        [MaxLength(25)]
        public required string DateOfBirth { get; set; }
        [MaxLength(25)]
        public required string Country { get; set; }
        [MaxLength(25)]
        public required string City { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Doctor Doctor { get; set; }
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Chat> Chats { get; set; } = [];
    }
}
