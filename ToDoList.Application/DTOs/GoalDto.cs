using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.DTOs
{
    public class GoalDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter description")]
        [MaxLength(500, ErrorMessage = "description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Create date is required")]
        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Required(ErrorMessage = "Please Choose color")]
        public string Color { get; set; } = string.Empty;
    }
}