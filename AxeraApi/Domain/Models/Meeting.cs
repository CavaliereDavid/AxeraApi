using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.Models;

public class Meeting
{
    public Meeting()
    {
        IsDeleted = false;
    }
    public Guid Id { get; set; }
    public DateTime ScheduledMeeting { get; set; }
    [Range(1, 1440)]
    public int Duration { get; set; }
    [MaxLength(1000)]
    public string? Note { get; set; }
    [Range(1, 100)]
    public int MaxUsers { get; set; }
    [Range(1, 100)]
    public int MinUsers { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid CourseID { get; set; }

    // Navigation property
    public Course Course { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
