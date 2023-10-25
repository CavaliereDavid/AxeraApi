using System;
using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.DTO;

public class ReservationDTO
{
    public Guid Id { get; set; }

    [MaxLength(1000)]
    public string? Note { get; set; }

    public bool? VerifiedPayment { get; set; }
    public bool? Withdraw { get; set; }
    public bool? IsDeleted { get; set; }

    public MeetingDTO Meeting { get; set; }

    public UserDTO User { get; set; }
}

public class CreateReservationRequestDTO
{
    [MaxLength(1000)]
    public string? Note { get; set; }
    public bool? VerifiedPayment { get; set; }
    public bool? Withdraw { get; set; }

    [Required(ErrorMessage = "MeetingID is required.")]
    public Guid MeetingID { get; set; }

    [Required(ErrorMessage = "UserID is required.")]
    public Guid UserID { get; set; }
}

public class UpdateReservationRequestDTO
{
    [MaxLength(1000)]
    public string? Note { get; set; }
    public bool? VerifiedPayment { get; set; }
    public bool? Withdraw { get; set; }

    [Required(ErrorMessage = "MeetingID is required.")]
    public Guid MeetingID { get; set; }

    [Required(ErrorMessage = "UserID is required.")]
    public Guid UserID { get; set; }
}

public class DeleteReservationRequestDTO
{
    public Guid Id { get; set; }

    [MaxLength(1000)]
    public string? Note { get; set; }
    public bool? VerifiedPayment { get; set; }
    public bool? Withdraw { get; set; }
    public bool? IsDeleted { get; set; }

    [Required(ErrorMessage = "MeetingID is required.")]
    public Guid MeetingID { get; set; }

    [Required(ErrorMessage = "UserID is required.")]
    public Guid UserID { get; set; }
}
