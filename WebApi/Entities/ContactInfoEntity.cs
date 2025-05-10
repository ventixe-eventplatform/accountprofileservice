using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class ContactInfoEntity
{
    [Key]
    public string ContactInfoId { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(Profile))]
    public string UserId { get; set; } = null!;
    public ProfileEntity Profile { get; set; } = null!;

    [ForeignKey(nameof(ContactType))]
    public int ContactTypeId { get; set; }
    public ContactTypeEntity ContactType { get; set; } = null!;
    public string? Value { get; set; }
}
