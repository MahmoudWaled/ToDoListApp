using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class Goal
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Required]
        public string Color { get; set; } = string.Empty;
    }
}