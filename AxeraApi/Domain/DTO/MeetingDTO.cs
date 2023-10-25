using System.ComponentModel.DataAnnotations;
using AxeraApi.CustomValidationAttribute;

namespace AxeraApi.Domain.DTO
{
    public class MeetingDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ScheduledMeeting is required.")]
        public DateTime ScheduledMeeting { get; set; }

        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440.")]
        public int Duration { get; set; }

        [MaxLength(1000, ErrorMessage = "Note cannot exceed 1000 characters.")]
        public string? Note { get; set; }

        [Range(1, 100, ErrorMessage = "MaxUsers must be between 1 and 100.")]
        public int MaxUsers { get; set; }
        [MinLessThanOrEqualToMax(ErrorMessage = "MinUsers must be less than or equal to MaxUsers.")]
        [Range(1, 100, ErrorMessage = "MinUsers must be between 1 and 100.")]
        public int MinUsers { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid CourseID { get; set; }
    }

    public class CreateMeetingRequestDTO
    {
        [Required(ErrorMessage = "ScheduledMeeting is required.")]
        public DateTime ScheduledMeeting { get; set; }

        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440.")]
        public int Duration { get; set; }

        [MaxLength(1000, ErrorMessage = "Note cannot exceed 1000 characters.")]
        public string? Note { get; set; }

        [Range(1, 100, ErrorMessage = "MaxUsers must be between 1 and 100.")]
        public int MaxUsers { get; set; }

        [MinLessThanOrEqualToMax(ErrorMessage = "MinUsers must be less than or equal to MaxUsers.")]
        [Range(1, 100, ErrorMessage = "MinUsers must be between 1 and 100.")]
        public int MinUsers { get; set; }

        public Guid CourseID { get; set; }
    }

    public class UpdateMeetingRequestDTO
    {
        [Required(ErrorMessage = "ScheduledMeeting is required.")]
        public DateTime ScheduledMeeting { get; set; }

        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440.")]
        public int Duration { get; set; }

        [MaxLength(1000, ErrorMessage = "Note cannot exceed 1000 characters.")]
        public string? Note { get; set; }

        [Range(1, 100, ErrorMessage = "MaxUsers must be between 1 and 100.")]
        public int MaxUsers { get; set; }
        [MinLessThanOrEqualToMax(ErrorMessage = "MinUsers must be less than or equal to MaxUsers.")]
        [Range(1, 100, ErrorMessage = "MinUsers must be between 1 and 100.")]
        public int MinUsers { get; set; }

        public Guid CourseID { get; set; }
    }

    public class DeleteMeetingRequestDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ScheduledMeeting is required.")]
        public DateTime ScheduledMeeting { get; set; }

        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440.")]
        public int Duration { get; set; }

        [MaxLength(1000, ErrorMessage = "Note cannot exceed 1000 characters.")]
        public string? Note { get; set; }

        [Range(1, 100, ErrorMessage = "MaxUsers must be between 1 and 100.")]
        public int MaxUsers { get; set; }
        [MinLessThanOrEqualToMax(ErrorMessage = "MinUsers must be less than or equal to MaxUsers.")]
        [Range(1, 100, ErrorMessage = "MinUsers must be between 1 and 100.")]
        public int MinUsers { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid CourseID { get; set; }
    }
}
