using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hospital_Management_System.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [MaxLength(255)]
        public required string role { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
