using System.ComponentModel.DataAnnotations;

namespace AxeraApi.Domain.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "ParticipantFullName is required.")]
    [MaxLength(100)]
    public string ParticipantFullName { get; set; }

    [Range(1, 100)]
    public int Age { get; set; }

    [MaxLength(100)]
    public string ParentFullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public bool? VerifiedUser { get; set; }
    public bool? IsNewsletterActive { get; set; }

    [MaxLength(500)]
    public string Allergies { get; set; }
    public bool? ConsentToPersonalData { get; set; }
    public bool? PrivacyPolicyAcknowledgement { get; set; }

    [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Invalid phone number.")]
    public int PhoneNumber { get; set; }
    public bool? IsDeleted { get; set; }
}

public class AddUserRequestDTO
{
    [Required(ErrorMessage = "ParticipantFullName is required.")]
    public string ParticipantFullName { get; set; }

    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public int Age { get; set; }

    [MaxLength(100)]
    public string ParentFullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public bool? VerifiedUser { get; set; }
    public bool? IsNewsletterActive { get; set; }

    [MaxLength(500)]
    public string Allergies { get; set; }
    public bool? ConsentToPersonalData { get; set; }
    public bool? PrivacyPolicyAcknowledgement { get; set; }

    [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Invalid phone number.")]
    public int PhoneNumber { get; set; }
}

public class UpdateUserRequestDTO
{
    [Required(ErrorMessage = "ParticipantFullName is required.")]
    public string ParticipantFullName { get; set; }

    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public int Age { get; set; }

    [MaxLength(100)]
    public string ParentFullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public bool? VerifiedUser { get; set; }
    public bool? IsNewsletterActive { get; set; }

    [MaxLength(500)]
    public string Allergies { get; set; }
    public bool? ConsentToPersonalData { get; set; }
    public bool? PrivacyPolicyAcknowledgement { get; set; }

    [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Invalid phone number.")]
    public int PhoneNumber { get; set; }
}

public class DeleteUserRequestDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "ParticipantFullName is required.")]
    public string ParticipantFullName { get; set; }

    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public int Age { get; set; }

    [MaxLength(100)]
    public string ParentFullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public bool? VerifiedUser { get; set; }
    public bool? IsNewsletterActive { get; set; }

    [MaxLength(500)]
    public string Allergies { get; set; }
    public bool? ConsentToPersonalData { get; set; }
    public bool? PrivacyPolicyAcknowledgement { get; set; }

    [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Invalid phone number.")]
    public int PhoneNumber { get; set; }
    public bool? IsDeleted { get; set; }
}

