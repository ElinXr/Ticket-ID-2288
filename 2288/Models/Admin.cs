
using System;
using System.ComponentModel.DataAnnotations;

namespace YourProject.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        // ... (Допълнителни свойства)
    }
}
