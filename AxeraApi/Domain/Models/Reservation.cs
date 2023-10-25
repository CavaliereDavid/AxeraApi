using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.Models;

public class Reservation
{
    public Reservation()
    {
        IsDeleted = false;
        Withdraw = false;
    }
    public Guid Id { get; set; }
    [MaxLength(1000)]
    public string? Note { get; set; }
    public bool? VerifiedPayment { get; set; }
    public bool? Withdraw { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid MeetingID { get; set; }
    public Guid UserID { get; set; }

    // Navigation property
    public Meeting Meeting { get; set; }
    public User User { get; set; }
}
