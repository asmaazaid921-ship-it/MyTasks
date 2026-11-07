using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;

public class TodoItem
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsCompleted { get; set; } = false;
    public string? AttachmentPath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}