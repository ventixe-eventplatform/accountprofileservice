using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class ContactInfoEntity
{
    [Key]
    [Column(TypeName = "varchar(36)")]
    public string ContactInfoId { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "varchar(36)")]
    [ForeignKey(nameof(Profile))]
    public string UserId { get; set; } = null!;
    public ProfileEntity Profile { get; set; } = null!;


    [ForeignKey(nameof(ContactType))]
    public int ContactTypeId { get; set; }
    public ContactTypeEntity ContactType { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string? Value { get; set; }
}
