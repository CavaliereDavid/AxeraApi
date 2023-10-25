using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.Models;

public class User
{
    public User()
    {
        IsDeleted = false;
        IsNewsletterActive = false;
    }
    public Guid Id { get; set; }
    [Required, MaxLength(100)]
    public string ParticipantFullName { get; set; }
    [Range(1, 100)]
    public int Age { get; set; }
    [MaxLength(100)]
    public string? ParentFullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    public bool? VerifiedUser { get; set; }
    public bool? IsNewsletterActive { get; set; }
    [MaxLength(500)]
    public string? Allergies { get; set; }
    public bool? ConsentToPersonalData { get; set; }
    public bool? PrivacyPolicyAcknowledgement { get; set; }
    [RegularExpression(@"^\d{9,15}$")]
    public int PhoneNumber { get; set; }
    public bool? IsDeleted { get; set; }

    // Navigation property

    public ICollection<Reservation> Reservations { get; set; }

}
