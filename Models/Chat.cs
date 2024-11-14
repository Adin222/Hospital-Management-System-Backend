﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        [MaxLength(255)]
        public string ChatName { get; set; }
        public ICollection<Message> Messages { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
