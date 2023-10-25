using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.Models;

public class Course
{
    public Course()
    {
        IsDeleted = false;
    }
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    public bool? IsDeleted { get; set; }

    // Navigation property
    public ICollection<Meeting> Meetings { get; set; }
}
