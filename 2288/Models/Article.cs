using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        // Връзка с таблицата Admins (ако е нужен потребител, който е създал статията)
        [ForeignKey("AuthorId")]
        public int? AuthorId { get; set; } // Позволява null стойност
        public Admin Author { get; set; }

        // ... (Допълнителни свойства)
    }
}

